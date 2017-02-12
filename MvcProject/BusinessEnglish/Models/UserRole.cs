namespace BusinessEnglish.Models
{
    using System.ComponentModel.DataAnnotations;

    public class UserRole
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Role Name")]
        public string RoleName { get; set; }
    }
}