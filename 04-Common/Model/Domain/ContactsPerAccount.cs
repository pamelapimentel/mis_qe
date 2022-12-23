using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Helper;
using Common.CustomFilters;

namespace Model.Domain
{
    public class ContactsPerAccount : AuditEntity, ISoftDeleted
    {
        public int Id { get; set; }
        public bool PrimaryAccount { get; set; }

        // Audit
        public bool Deleted { get; set; }

        // FK Contact
        public Contact Contact { get; set; }
        public int ContactId { get; set; }

        // FK Account
        public Account Account { get; set; }
        public int AccountId { get; set; }
    }
}
