using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Security.Claims;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using Model.Domain;
using Common;
using Task = System.Threading.Tasks.Task;

namespace Model.Auth
{
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            userIdentity = await CreateUserClaims(userIdentity, manager, userIdentity.GetUserId());

            // Add custom user claims here
            return userIdentity;
        }

        public async static Task<ClaimsIdentity> CreateUserClaims(ClaimsIdentity identity, UserManager<ApplicationUser> manager, string userId)
        {
            // Current User
            var currentUser = await manager.FindByIdAsync(userId);
            var roles = (List<string>)await manager.GetRolesAsync(userId);

            // Your User Data
            var jUser = JsonConvert.SerializeObject(new CurrentUser
            {
                UserId = currentUser.Id,
                Name = currentUser.FirstName,
                UserName = currentUser.Email,
                Roles = roles ?? new List<string>()
            });

            identity.AddClaim(new Claim(ClaimTypes.UserData, jUser));

            return await Task.FromResult(identity);
        }

        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string FatherLastName { get; set; }
        public string MotherLastName { get; set; }
        public Enums.StatusUser StatusUser { get; set; }
        public string AddressStreet { get; set; }

        public District District { get; set; }
        public int? DistrictId { get; set; }
    }
}
