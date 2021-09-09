using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMpublishers.Data.Models
{
    public class State
    {
        public int Id { get; set; }

        public string name { get; set; }

        public string fullname { get; set; }
        public DateTime timestamp { get; set; }

        public ICollection<City> cities { get; set; }


    }
}
