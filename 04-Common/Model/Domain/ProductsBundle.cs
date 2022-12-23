using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Helper;
using Common.CustomFilters;

namespace Model.Domain
{
    public class ProductsBundle : AuditEntity, ISoftDeleted
    {
        public int Id { get; set; }
        public string ProductsBundleName { get; set; }
        public string Description { get; set; }

        public decimal SubTotal { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal DiscountRatePercent { get; set; }
        public int Quantity { get; set; }

        // Audit
        public bool Deleted { get; set; }

        //FK Quote
        public Quote Quote { get; set; }
        public int QuoteId { get; set; }

        // FK ProductsPerProductsBundle
        public ICollection<ProductsPerProductsBundle> Products { get; set; }
    }
}
