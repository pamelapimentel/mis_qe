using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Domain
{
    public class Group
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
        public string Description { get; set; }

        //FK Line
        public Line Line { get; set; }
        public int LineId { get; set; }
    }
}
