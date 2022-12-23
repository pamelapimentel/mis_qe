using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Auth;
using Model.Helper;
using Common.CustomFilters;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Model.Domain
{
    public class Contact : AuditEntity, ISoftDeleted
    {
        public int Id { get; set; }
        public string Salutation { get; set; }
        [Description("Nombre")]
        [Required]
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        [Description("Apellidos")]
        [Required]
        public string FatherLastName { get; set; }
        public string MotherLastName { get; set; }
        public string JobTitle { get; set; }
        public string Department { get; set; }
        public string PhoneWork { get; set; }
        public string PhoneMobile { get; set; }
        public string AddressStreet { get; set; }
        public string Birthdate { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        // Audit
        public bool Deleted { get; set; }

        // FK District
        public District District { get; set; }
        public int? DistrictId { get; set; }

    }
}
