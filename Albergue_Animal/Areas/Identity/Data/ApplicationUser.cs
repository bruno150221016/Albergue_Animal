using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Albergue_Animal.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {

        [Required]
        public String Nome { get; set; }

        [Required]
        public String Morada { get; set; }

        [Required]
        public String Telefone { get; set; }


        public String Fotografia { get; set; }

    }
}
