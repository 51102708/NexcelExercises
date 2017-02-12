namespace BusinessEnglish.Sites.Models
{
    using System.ComponentModel.DataAnnotations;

    public class AdminViewModel
    {
        [Required(ErrorMessage = "Username required.")]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}