using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMpublishers.Data.Models
{
    public class City
    {
        public int Id { get; set; }
        public string name { get; set; }
        public DateTime timestamp { get; set; }

        public int stateID { get; set; }

        public virtual State state { get; set; }



    }
}
