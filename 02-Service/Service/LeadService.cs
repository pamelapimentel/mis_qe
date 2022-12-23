using Common;
using Model.Auth;
using Model.Custom;
using Model.Domain;
using NLog;
using Persistence.DbContextScope;
using Persistence.DbContextScope.Extensions;
using Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface ILeadService
    {
        ResponseHelper InsertOrUpdate(Lead model);
        AnexGRIDResponde GetAll(AnexGRID grid);
    }
    public class LeadService : ILeadService
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        private readonly IRepository<Lead> _leadRepo;

        public LeadService(IDbContextScopeFactory dbContextScopeFactory, IRepository<Lead> leadRepo)
        {
            _dbContextScopeFactory = dbContextScopeFactory;
            _leadRepo = leadRepo;
        }

        public ResponseHelper InsertOrUpdate(Lead model)
        {
            var rh = new ResponseHelper();
            try
            {
                using (var ctx = _dbContextScopeFactory.Create()) 
                {
                    if (model.Id > 0)
                    {
                        var originaLead = _leadRepo.Single(x => x.Id == model.Id);
                        originaLead.LeadName = model.LeadName;
                        originaLead.Account.Name = model.Account.Name;
                        originaLead.Contact.FirstName = model.Contact.FirstName;
                        originaLead.Contact.FatherLastName = model.Contact.FatherLastName;
                        originaLead.AssignedUserId = model.AssignedUserId;
                        originaLead.Description = model.Description;
                        originaLead.Amount = model.Amount;

                        originaLead.AssignedUserId = originaLead.AssignedUserId;

                        _leadRepo.Update(originaLead);
                    }
                    else
                    {
                        _leadRepo.Insert(model);
                    }
                    
                    ctx.SaveChanges();
                    rh.SetResponse(true);
                }

            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                rh.SetResponse(false, e.Message);
            }
            return rh;
        }

        public AnexGRIDResponde GetAll(AnexGRID grid)
        {
            grid.Inicializar();

            try
            {
                using (var ctx = _dbContextScopeFactory.Create())
                {
                    var user = ctx.GetEntity<ApplicationUser>();
                    var roles = ctx.GetEntity<ApplicationRole>();
                    var userRoles = ctx.GetEntity<ApplicationUserRole>();
                    var opportunities = ctx.GetEntity<Opportunity>();

                    var queryRoles = (
                        from r in roles
                        from ur in userRoles.Where(x => x.RoleId == r.Id)
                        select new {
                            UserId = ur.UserId,
                            Role = r.Name
                        }
                    ).AsQueryable();

                    var query = (
                        from u in user
                        select new UserForGridView
                        {
                            Id = u.Id,
                            FullName = u.FirstName + " " + u.FatherLastName + " " + u.MotherLastName,
                            Email = u.Email,
                            OpportunitiesClosed = opportunities.Where(x => x.AssignedUserId == u.Id).Count(),
                            Roles = queryRoles.Where(x => x.UserId == u.Id).Select(x => x.Role).ToList()
                        }
                    ).AsQueryable();

                    // Order by
                    if (grid.columna == "FullName")
                    {
                        query = grid.columna_orden == "DESC" ? query.OrderByDescending(x => x.FullName)
                                                             : query.OrderBy(x => x.FullName);
                    }

                    var data = query.Skip(grid.pagina)
                                    .Take(grid.limite)
                                    .ToList();

                    var total = query.Count();

                    grid.SetData(data, total);
                }

            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }
            return  grid.responde();
        }

    }
}
