namespace BusinessEnglish.Sites.ViewModels.Admin
{
    using Resources;
    using System.ComponentModel.DataAnnotations;

    public class LoginViewModel
    {
        [Required(ErrorMessageResourceType = typeof(StringResources), ErrorMessageResourceName = "UsernameRequired")]
        [Display(ResourceType = typeof(StringResources), Name = "UserName")]
        public string UserName { get; set; }

        [Required(ErrorMessageResourceType = typeof(StringResources), ErrorMessageResourceName = "PasswordRequired")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}