using System.ComponentModel.DataAnnotations;

namespace Auth.Application.ViewModels
{
    public class LoginUserViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Informe o email")]
        public string Email { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Informe a senha")]
        public string Password { get; set; }
    }
}
