using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Domain
{
    public class District
    {
        public int Id { get; set; }
        public string DistrictName { get; set; }

        public City City { get; set; }
        public int CityId { get; set; }
    }
}
