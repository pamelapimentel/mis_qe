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
    public interface IUserService 
    {
        ResponseHelper Update(ApplicationUser model);
        AnexGRIDResponde GetAll(AnexGRID grid);
    }
    public class UserService : IUserService
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        private readonly IRepository<ApplicationUser> _applicationUserRepo;

        public UserService(IDbContextScopeFactory dbContextScopeFactory, IRepository<ApplicationUser> applicationUserRepo)
        {
            _dbContextScopeFactory = dbContextScopeFactory;
            _applicationUserRepo = applicationUserRepo;
        }

        public ResponseHelper Update(ApplicationUser model)
        {
            var rh = new ResponseHelper();
            try
            {
                using (var ctx = _dbContextScopeFactory.Create()) 
                {
                    var originalModel = _applicationUserRepo.Single(x => x.Id == model.Id);
                    originalModel.FirstName = model.FirstName;
                    originalModel.FatherLastName = model.FatherLastName;
                    originalModel.MotherLastName = model.MotherLastName;
                    originalModel.PhoneNumber = model.PhoneNumber;

                    _applicationUserRepo.Update(originalModel);
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

        public IEnumerable<ApplicationUser> GetAll(int categoryId = 0)
        {
            var result = new List<ApplicationUser>();

            try
            {
                using (var ctx = _dbContextScopeFactory.CreateReadOnly())
                {
                    var user = ctx.GetEntity<ApplicationUser>();
                    var roles = ctx.GetEntity<ApplicationRole>();
                    var userRoles = ctx.GetEntity<ApplicationUserRole>();

                    var query = (
                        from u in user
                        from ur in userRoles.Where(x => x.RoleId == u.Id)
                        from r in roles.Where(x => x.Id == "Vendedores")
                        select new
                        {
                            UserName = u.FirstName + ' ' + u.FatherLastName,
                            UserId = u.Id
                        }
                    ).AsQueryable();
                    
                    //result = query.

                    //if (categoryId == 0)
                    //{
                    //    query = query.OrderBy(x => Guid.NewGuid());
                    //}
                    //else
                    //{
                    //    //revisar el id
                    //    query = query.Where(x => x.Id == categoryId)
                    //                 .OrderBy(x => Guid.NewGuid());
                    //}


                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }

            return result;
        }
    }
}
