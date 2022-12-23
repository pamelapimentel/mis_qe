using Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Custom
{
    public class ContactCard
    {
        public int Id { get; set; }
        public string Salutation { get; set; }
        public int ContactsPerAccountsId { get; set; }
        public bool PrimaryAccount { get; set; }
        public int ContactId { get; set; }
        public int AccountId { get; set; }
        public string AccountName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string JobTitle { get; set; }
        public string PhoneMobile { get; set; }
        public string UpdatedById { get; set; }
        public string UpdatedByName { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string FatherLastName { get; set; }
        public string MotherLastName { get; set; }

    }
}
