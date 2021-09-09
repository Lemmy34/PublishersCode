using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMpublishers.Data.Dto
{
    public class CityDto
    {
        public int Id { get; set; }
        public string name { get; set; }
        public int stateID { get; set; }
        public string  state { get; set; }
    }
}
