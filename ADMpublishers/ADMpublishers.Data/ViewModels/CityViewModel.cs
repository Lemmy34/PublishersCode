using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMpublishers.Data.ViewModels
{
    public class CityViewModel
    {
        public int Id { get; set; }
        public string name { get; set; }

        public virtual StateViewModel state { get; set; }
    }
}
