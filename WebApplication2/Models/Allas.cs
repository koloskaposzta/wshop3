using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class Allas
    {
        [Key]
        public string UID { get; set; }
        public string Vallalat { get; set; }
        public string Megnevezes { get; set; }
        public int Oraber { get; set; }
        public virtual ICollection<SiteUser> Jelentkezok { get; set; }
        public Allas()
        {
            this.Jelentkezok = new HashSet<SiteUser>();
        }
    }
}
