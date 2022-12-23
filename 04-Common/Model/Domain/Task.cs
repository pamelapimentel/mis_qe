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
    public class Task : AuditEntity, ISoftDeleted
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        public Enums.StatusTask StatusTask { get; set; }
        public string Description { get; set; }
        public DateTime? DateLimit { get; set; }
        public Enums.PriorityTask PriorityTask { get; set; }
        public Enums.TypeTask TypeTask { get; set; }
        public string ParentType { get; set; }
        public Enums.EntityType EntityType { get; set; }
        public int EntityId { get; set; }

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
