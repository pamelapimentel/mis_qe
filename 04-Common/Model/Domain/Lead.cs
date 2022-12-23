using Common;
using Model.Auth;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Helper;
using Common.CustomFilters;

namespace Model.Domain
{
    public class Lead : AuditEntity, ISoftDeleted
    {
        public int Id { get; set; }
        public string LeadName { get; set; }
        public Enums.RankingLead RankingLead { get; set; }
        public Enums.StatusLead StatusLead { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public Enums.Currency Currency { get; set; }

        // Audit
        public bool Deleted { get; set; }

        // FK AspNetUser
        [ForeignKey("AssignedUserId")]
        public ApplicationUser AssignedUser { get; set; }
        public string AssignedUserId { get; set; }

        // FK Contact
        public Contact Contact { get; set; }
        public int ContactId { get; set; }

        // FK Account
        public Account Account { get; set; }
        public int AccountId { get; set; }
    }
}
