using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace General.WebUI.Identity
{
    public class ApplicationUser:IdentityUser
    {
        public string FullName { get; set; }
        public string BirthDate { get; set; }
        public string RegisterDate { get; set; }

    }
}
