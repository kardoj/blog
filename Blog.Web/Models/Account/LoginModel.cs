using System.ComponentModel.DataAnnotations;

namespace Blog.Web.Models.Account
{
    public class LoginModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
