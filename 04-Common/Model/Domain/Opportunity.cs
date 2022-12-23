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
    public class Opportunity : AuditEntity, ISoftDeleted
    {
        public int Id { get; set; }
        public string OpportunityName { get; set; }
        public Enums.ProbabilityOpportunity ProbabilityOpportunity { get; set; }
        public Enums.SolutionType SolutionType { get; set; }
        public Enums.StatusOpportunity StatusOpportunity { get; set; }
        public string Description { get; set; }
        public Enums.StageOpportunity StageOpportunity { get; set; }
        public DateTime? DateClosed { get; set; }
        public decimal Amount { get; set; }
        public Enums.Currency Currency { get; set; }
        public string AddressStreet { get; set; }

        // Audit
        public bool Deleted { get; set; }

        // FK District
        public District District { get; set; }
        public int? DistrictId { get; set; }

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

        // FK Lead
        public Lead Lead { get; set; }
        public int? LeadId { get; set; }

        // FK QuotesPerOpportunity
        public ICollection<QuotesPerOpportunity> Quotes { get; set; }
    }
}
