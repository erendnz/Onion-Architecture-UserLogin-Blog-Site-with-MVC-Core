using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.Entities
{
    public class AppUser : IdentityUser<int>
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
    }
}
