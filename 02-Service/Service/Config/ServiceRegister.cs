using LightInject;
using Model.Auth;
using Model.Domain;
using Persistence.DbContextScope;
using Persistence.Repository;

namespace Service.Config
{
    public class ServiceRegister : ICompositionRoot
    {               
        public void Compose(IServiceRegistry container)
        {
            var ambientDbContextLocator = new AmbientDbContextLocator();

            container.Register<IDbContextScopeFactory>((x) => new DbContextScopeFactory(null));
            container.Register<IAmbientDbContextLocator, AmbientDbContextLocator>(new PerScopeLifetime());

            container.Register<IRepository<ApplicationUser>>((x) => new Repository<ApplicationUser>(ambientDbContextLocator));
            container.Register<IRepository<ApplicationRole>>((x) => new Repository<ApplicationRole>(ambientDbContextLocator));
            container.Register<IRepository<ApplicationUserRole>>((x) => new Repository<ApplicationUserRole>(ambientDbContextLocator));
            container.Register<IRepository<Contact>>((x) => new Repository<Contact>(ambientDbContextLocator));
            container.Register<IRepository<Lead>>((x) => new Repository<Lead>(ambientDbContextLocator));
            container.Register<IRepository<Account>>((x) => new Repository<Account>(ambientDbContextLocator));
            container.Register<IRepository<ContactsPerAccount>>((x) => new Repository<ContactsPerAccount>(ambientDbContextLocator));

            container.Register<IUserService, UserService>();
            container.Register<IContactService, ContactService>();
            container.Register<ILeadService, LeadService>();
            container.Register<IAccountsService, AccountsService>();
        }
    }
}
