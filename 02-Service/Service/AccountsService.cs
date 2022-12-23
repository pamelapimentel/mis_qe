using Common;
using Model.Auth;
using Model.Custom;
using Model.Domain;
using Newtonsoft.Json;
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
    public interface IAccountsService
    {
        AnexGRIDResponde GetAll(AnexGRID grid, int id = 0);
        AccountsCard Detail(int id);
        IEnumerable<Account> GetAll();
    }
    public class AccountsService : IAccountsService
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        private readonly IRepository<Account> _accountRepo;

        public AccountsService(IDbContextScopeFactory dbContextScopeFactory, IRepository<Account> accountRepo)
        {
            _dbContextScopeFactory = dbContextScopeFactory;
            _accountRepo = accountRepo;
        }
        public AnexGRIDResponde GetAll(AnexGRID grid, int id)
        {
            grid.Inicializar();

            try
            {
                using (var ctx = _dbContextScopeFactory.CreateReadOnly())
                {
                    var contacts = ctx.GetEntity<Contact>();
                    var contactsperaccounts = ctx.GetEntity<ContactsPerAccount>();
                    var accounts = ctx.GetEntity<Account>();
                    IQueryable<AccountsCard> query;

                    if (id > 0)
                    {
                        query = (
                            from a in accounts
                            from ca in contactsperaccounts.Where(x => x.AccountId == a.Id)
                            from c in contacts.Where(x => x.Id == ca.ContactId)
                            where ca.PrimaryAccount == true && a.Id == id
                            select new AccountsCard
                            {
                                Id = a.Id,
                                ContactsPerAccountsId = ca.Id,
                                PrimaryAccount = ca.PrimaryAccount,
                                ContactId = ca.ContactId,
                                AccountId = ca.AccountId,
                                AccountName = a.Name,
                                FullName = (c.FirstName + " " + c.FatherLastName),
                                Industry = a.Industry,
                                Sector = a.Sector,
                                PhoneOffice = a.PhoneOffice
                            //Students = queryStudents.Where(x => x.CourseId == c.Id).Count()
                        }
                        ).AsQueryable();
                    }
                    else
                    {
                        query = (
                            from a in accounts
                            from ca in contactsperaccounts.Where(x => x.AccountId == a.Id)
                            from c in contacts.Where(x => x.Id == ca.ContactId)
                            where ca.PrimaryAccount == true 
                            select new AccountsCard
                            {
                                Id = a.Id,
                                ContactsPerAccountsId = ca.Id,
                                PrimaryAccount = ca.PrimaryAccount,
                                ContactId = ca.ContactId,
                                AccountId = ca.AccountId,
                                AccountName = a.Name,
                                FullName = (c.FirstName + " " + c.FatherLastName),
                                Industry = a.Industry,
                                Sector = a.Sector,
                                PhoneOffice = a.PhoneOffice
                                //Students = queryStudents.Where(x => x.CourseId == c.Id).Count()
                            }
                        ).AsQueryable();
                    }

                    // Order by
                    if (grid.columna == "AccountName")
                    {
                        query = grid.columna_orden == "DESC" ? query.OrderByDescending(x => x.AccountName)
                                                             : query.OrderBy(x => x.AccountName);
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

            return grid.responde();
        }
        public AccountsCard Detail(int id)
        {
            var result = new AccountsCard();

            try
            {
                using (var ctx = _dbContextScopeFactory.CreateReadOnly())
                {
                    var contacts = ctx.GetEntity<Contact>();
                    var contactsperaccounts = ctx.GetEntity<ContactsPerAccount>();
                    var accounts = ctx.GetEntity<Account>();

                    var query = (
                        from a in accounts
                        from ca in contactsperaccounts.Where(x => x.AccountId == a.Id)
                        from c in contacts.Where(x => x.Id == ca.ContactId)
                        where ca.PrimaryAccount == true && a.Id == id
                        select new AccountsCard
                        {
                            Id = a.Id,
                            ContactsPerAccountsId = ca.Id,
                            PrimaryAccount = ca.PrimaryAccount,
                            ContactId = ca.ContactId,
                            AccountId = ca.AccountId,
                            AccountName = a.Name,
                            PhoneOffice = a.PhoneOffice,
                            AccountEmail = a.Email,
                            Industry = a.Industry,
                            Sector = a.Sector,
                            FullName = (c.FirstName + " " + c.FatherLastName)
                            //Students = queryStudents.Where(x => x.CourseId == c.Id).Count()
                        }
                    ).AsQueryable();

                    result = query.SingleOrDefault();
                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }

            return result;
        }
        public IEnumerable<Account> GetAll()
        {
            var result = new List<Account>();

            try
            {
                using (var ctx = _dbContextScopeFactory.CreateReadOnly())
                {
                    result = _accountRepo.GetAll().OrderBy(x => x.Name).ToList();
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
