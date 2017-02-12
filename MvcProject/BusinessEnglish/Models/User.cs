namespace BusinessEnglish.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Username required.")]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password required.")]
        public string Password { get; set; }

        public int UserRoleId { get; set; }

        public UserRole UserRole { get; set; }
    }
}