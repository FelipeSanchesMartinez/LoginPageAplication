using System.ComponentModel.DataAnnotations;

namespace Auth.Application.ViewModels
{
    public class RegisterUserViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Informe o email")]
        public string Email { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Informe senhas iguais")]
        public string Password { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Informe senhas iguais")]
        public string ConfirmPassword { get; set; }
    }
}
