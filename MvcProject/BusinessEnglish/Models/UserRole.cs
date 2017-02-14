namespace BusinessEnglish.Services.Models
{
    using Resources;
    using System.ComponentModel.DataAnnotations;

    public class UserRole
    {
        public int Id { get; set; }

        [Required]
        [Display(ResourceType = typeof(StringResources), Name = "RoleName")]
        public string RoleName { get; set; }
    }
}