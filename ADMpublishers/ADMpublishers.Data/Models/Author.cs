using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMpublishers.Data.Models
{
    public class Author
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public string au_id  { get; set; }

        public string au_lname { get; set; }

        public string au_fname { get; set; }

        public string phone { get; set; }

        public string address { get; set; }

        public int cityID { get; set; }
        public string zip { get; set; }

        public int contract { get; set; }

        public DateTime timestamp { get; set; }

        public virtual City city { get; set; }


    }
}
