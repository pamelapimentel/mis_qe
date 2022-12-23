using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace Model.Custom
{
    public class AccountsCard
    {
        public int Id { get; set; }
        public int ContactsPerAccountsId { get; set; }
        public bool PrimaryAccount { get; set; }
        public int ContactId { get; set; }
        public int AccountId { get; set; }
        public string AccountName { get; set; }
        public string FullName { get; set; }
        public string PhoneOffice { get; set; }
        public string WebSite { get; set; }
        public string AccountEmail { get; set; }
        public Enums.Industry Industry { get; set; }
        public Enums.Sector Sector { get; set; }

    }
}
