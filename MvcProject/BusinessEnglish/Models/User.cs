namespace BusinessEnglish.Services.Models
{
    using Resources;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessageResourceType = typeof(StringResources), ErrorMessageResourceName = "UsernameRequired")]
        [Display(ResourceType = typeof(StringResources), Name = "UserName")]
        public string UserName { get; set; }

        [Required(ErrorMessageResourceType = typeof(StringResources), ErrorMessageResourceName = "PasswordRequired")]
        public string Password { get; set; }

        public int UserRoleId { get; set; }

        public UserRole UserRole { get; set; }
    }
}