using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Common.CustomFilters;
using Model.Auth;
using Model.Helper;

namespace Model.Domain
{
    public class Account : AuditEntity, ISoftDeleted
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Enums.Industry Industry { get; set; }
        public Enums.Sector Sector { get; set; }
        public string PhoneOffice { get; set; }
        public string PhoneAlternate { get; set; }
        public string WebSite { get; set; }
        public string PhoneWork { get; set; }
        public string PhoneMobile { get; set; }
        public string AddressStreet { get; set; }
        public string Email { get; set; }
        public string Origin { get; set; }

        // Audit
        public bool Deleted { get; set; }

        // FK District
        public District District { get; set; }
        public int? DistrictId { get; set; }

        // FK ContactsPerAccount
        public ICollection<ContactsPerAccount> Contacts  { get; set; }
  
    }
}
