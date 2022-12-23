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
    public class Quote : AuditEntity, ISoftDeleted
    {
        public int Id { get; set; }
        public string QuoteNum { get; set; }
        public Enums.StatusQuote StatusQuote { get; set; }
        public string Version { get; set; }
        public string Comments { get; set; }
        public DateTime? DateQuoteClosed { get; set; }
        public string PaymentTerms { get; set; }
        public int DeliveryConditions { get; set; }
        public string Observations { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }
        public decimal TaxValue { get; set; }
        public decimal Shipping { get; set; }
        public Enums.Currency Currency { get; set; }

        // Audit
        public bool Deleted { get; set; }

        // FK AspNetUser
        [ForeignKey("AssignedUserId")]
        public ApplicationUser AssignedUser { get; set; }
        public string AssignedUserId { get; set; }

        // FK Contact
        public Contact Contact { get; set; }
        public int? ContactId { get; set; }

        // FK Account
        public Account Account { get; set; }
        public int? AccountId { get; set; }
    }
}
