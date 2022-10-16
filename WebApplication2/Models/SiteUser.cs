using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class SiteUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int MinimumOraber { get; set; }

        public virtual ICollection<Allas> Allasok { get; set; }

        public SiteUser():base()
        {
            this.Allasok = new HashSet<Allas>();
        }
    }
}
