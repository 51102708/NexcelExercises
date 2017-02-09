using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEnglish.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Username required.")]
        [Display(Name = "User Name")]
        public virtual string UserName { get; set; }

        [Required(ErrorMessage = "Username required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}