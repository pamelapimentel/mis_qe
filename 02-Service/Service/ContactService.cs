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
    public interface IContactService
    {
        ResponseHelper InsertOrUpdate(ContactCard model);
        AnexGRIDResponde GetAll(AnexGRID grid);
        IEnumerable<ContactCard> GetAll(int categoryId = 0);
        Contact Get(int id);
        ContactCard Detail(int id);
        ResponseHelper Delete(int id);
    }
    public class ContactService : IContactService
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        private readonly IRepository<Contact> _contactRepo;
        private readonly IRepository<ContactsPerAccount> _contactsperaccountRepo;

        public ContactService (IDbContextScopeFactory dbContextScopeFactory, IRepository<Contact> contactRepo, IRepository<ContactsPerAccount> contactsperaccountRepo) 
        {
            _dbContextScopeFactory = dbContextScopeFactory;
            _contactRepo = contactRepo;
            _contactsperaccountRepo = contactsperaccountRepo;
        }

        public ResponseHelper InsertOrUpdate(ContactCard model)
        {
            var rh = new ResponseHelper();
            var newRecord = false;

            try
            {
                using (var ctx = _dbContextScopeFactory.Create())
                {
                    if (model.Id > 0)
                    {
                        var originalContact = _contactRepo.Single(x => x.Id == model.Id);

                        originalContact.Salutation = model.Salutation;
                        originalContact.FirstName = model.FirstName;
                        originalContact.SecondName = model.SecondName;
                        originalContact.FatherLastName = model.FatherLastName;
                        originalContact.MotherLastName = model.MotherLastName;
                        originalContact.PhoneMobile = model.PhoneMobile;
                        originalContact.JobTitle = model.JobTitle;
                        originalContact.Email = model.Email;

                        _contactRepo.Update(originalContact);

                        var originalContactxAccount = _contactsperaccountRepo.Single(x => x.Id == model.Id);

                        originalContactxAccount.PrimaryAccount = model.PrimaryAccount;
                        originalContactxAccount.ContactId = model.ContactId;
                        originalContactxAccount.AccountId = model.AccountId;

                        _contactsperaccountRepo.Update(originalContactxAccount);


                    }
                    else
                    {
                        newRecord = true;

                        // Después de insertar el campo Id ya tiene ID
                        _contactRepo.Insert(new Contact {
                            Salutation = model.Salutation,
                            FirstName = model.FirstName,
                            SecondName = model.SecondName,
                            FatherLastName = model.FatherLastName,
                            MotherLastName = model.MotherLastName,
                            PhoneMobile = model.PhoneMobile,
                            JobTitle = model.JobTitle,
                            Email = model.Email
                        });

                        _contactsperaccountRepo.Insert(new ContactsPerAccount
                        {
                            PrimaryAccount = model.PrimaryAccount,
                            ContactId = model.ContactId,
                            AccountId = model.AccountId
                        });
                    }

                    ctx.SaveChanges();
                }

                if (newRecord)
                {
                    using (var ctx = _dbContextScopeFactory.Create())
                    {
                        // Obtenemos el registro insertado
                        var originalContact = _contactRepo.Single(x => x.Id == model.Id);

                        //originalCategory.Slug = Slug.Category(model.Id, model.Name);

                        // Actualizamos
                        _contactRepo.Update(originalContact);

                        ctx.SaveChanges();
                    }
                }
                rh.SetResponse(true);
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                rh.SetResponse(false, e.Message);
            }

            return rh;
        }

        public IEnumerable<ContactCard> GetAll(int categoryId = 0)
        {
            var result = new List<ContactCard>();

            try
            {
                using (var ctx = _dbContextScopeFactory.CreateReadOnly())
                {
                    var contacts = ctx.GetEntity<Contact>();
                    var contactsperaccounts = ctx.GetEntity<ContactsPerAccount>();
                    var accounts = ctx.GetEntity<Account>();

                    var query = (
                        from c in contacts
                        from ca in contactsperaccounts.Where(x => x.ContactId == c.Id)
                        from a in accounts.Where(x => x.Id == ca.AccountId)
                        select new ContactCard
                        {
                            Id = c.Id,
                            Salutation = c.Salutation,
                            ContactsPerAccountsId = ca.Id,
                            PrimaryAccount = ca.PrimaryAccount,
                            ContactId = ca.ContactId,
                            AccountId = ca.AccountId,
                            AccountName = a.Name,
                            FullName = (c.FirstName + " " + c.FatherLastName),
                            Email = c.Email,
                            JobTitle = c.JobTitle
                            //Students = queryStudents.Where(x => x.CourseId == c.Id).Count()
                        }
                    ).AsQueryable();

                    if (categoryId == 0)
                    {
                        query = query.OrderBy(x => Guid.NewGuid());
                    }
                    else
                    {
                        //revisar el id
                        query = query.Where(x => x.Id == categoryId)
                                     .OrderBy(x => Guid.NewGuid());
                    }

                    
                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }

            return result;
        }

        public AnexGRIDResponde GetAll(AnexGRID grid)
        {
            grid.Inicializar();

            try
            {
                using (var ctx = _dbContextScopeFactory.CreateReadOnly())
                {
                    var contacts = ctx.GetEntity<Contact>();
                    var contactsperaccounts = ctx.GetEntity<ContactsPerAccount>();
                    var accounts = ctx.GetEntity<Account>();

                    var query = (
                        from c in contacts
                        from ca in contactsperaccounts.Where(x => x.ContactId == c.Id)
                        from a in accounts.Where(x => x.Id == ca.AccountId)
                        select new ContactCard
                        {
                            Id = c.Id,
                            Salutation = c.Salutation,
                            ContactsPerAccountsId = ca.Id,
                            PrimaryAccount = ca.PrimaryAccount,
                            ContactId = ca.ContactId,
                            AccountId = ca.AccountId,
                            AccountName = a.Name,
                            FullName = (c.FirstName + " " + c.FatherLastName),
                            Email = c.Email,
                            JobTitle = c.JobTitle
                            //Students = queryStudents.Where(x => x.CourseId == c.Id).Count()
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

            return grid.responde();
        }

        public Contact Get(int id)
        {
            var result = new Contact();

            try
            {
                using (var ctx = _dbContextScopeFactory.CreateReadOnly())
                {
                    result = _contactRepo.SingleOrDefault(x => x.Id == id);
                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }

            return result;
        }

        public ResponseHelper Delete(int id)
        {
            var result = new ResponseHelper();

            try
            {
                using (var ctx = _dbContextScopeFactory.Create())
                {
                    var originalContact = _contactRepo.Single(x => x.Id == id);
                    _contactRepo.Delete(originalContact);

                    result.SetResponse(true);

                    ctx.SaveChanges();
                }

                if (result.Response)
                {
                    //Parameters.CategoryList = GetForMenu();
                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }

            return result;
        }

        public ContactCard Detail(int id)
        {
            var result = new ContactCard();

            try
            {
                using (var ctx = _dbContextScopeFactory.CreateReadOnly())
                {
                    var contacts = ctx.GetEntity<Contact>();
                    var contactsperaccounts = ctx.GetEntity<ContactsPerAccount>();
                    var accounts = ctx.GetEntity<Account>();
                    var user = ctx.GetEntity<ApplicationUser>();

                    var query = (
                        from c in contacts
                        from ca in contactsperaccounts.Where(x => x.ContactId == c.Id)
                        from a in accounts.Where(x => x.Id == ca.AccountId)
                        from u in user.Where(x => x.Id == c.UpdatedBy)
                        where c.Id == id
                        
                        select new ContactCard
                        {
                            Id = c.Id,
                            Salutation = c.Salutation,
                            ContactsPerAccountsId = ca.Id,
                            PrimaryAccount = ca.PrimaryAccount,
                            ContactId = ca.ContactId,
                            AccountId = ca.AccountId,
                            AccountName = a.Name,
                            FirstName = c.FirstName,
                            SecondName = c.SecondName,
                            FatherLastName = c.FatherLastName,
                            MotherLastName = c.MotherLastName,
                            FullName = (c.FirstName + " " + c.FatherLastName),
                            PhoneMobile = c.PhoneMobile,
                            Email = c.Email,
                            JobTitle = c.JobTitle,
                            UpdateAt = c.UpdatedAt,
                            UpdatedByName = (u.FirstName + " " + u.FatherLastName)
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
    }
    
}
