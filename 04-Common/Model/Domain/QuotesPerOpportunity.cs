using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Helper;
using Common.CustomFilters;

namespace Model.Domain
{
    public class QuotesPerOpportunity : AuditEntity, ISoftDeleted
    {
        public int Id { get; set; }

        // Audit
        public bool Deleted { get; set; }

        // FK Quote
        public Quote Quote { get; set; }
        public int QuoteId { get; set; }

        // FK Opportunity
        public Opportunity Opportunity { get; set; }
        public int OpportunityId { get; set; }
    }
}
