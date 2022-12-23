using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Helper;
using Common.CustomFilters;

namespace Model.Domain
{
    public class ProductsPerProductsBundle : AuditEntity, ISoftDeleted
    {
        public int Id { get; set; }

        // Audit
        public bool Deleted { get; set; }

        // FK ProductsBundle
        public ProductsBundle ProductsBundle { get; set; }
        public int? ProductsBundleId { get; set; }

        // FK Product
        public Product Product { get; set; }
        public int ProductId { get; set; }
    }
}
