using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace General.WebUI.Models
{
    public class EditUser
    {
        public EditUser()
        {
            Roles = new List<string>();           

        }
        public string Id { get; set; }

        [Required]
        public string UserName { get; set; }
        [Required][EmailAddress]
        public string Email { get; set; }
        public IList<string> Roles { get; set; }

    }
}
