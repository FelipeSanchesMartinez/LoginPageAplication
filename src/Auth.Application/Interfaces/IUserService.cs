using Auth.Application.Services;
using Auth.Application.ViewModels;
using Auth.Domain.Entities;

namespace Auth.Application.Interfaces
{
    public interface IUserService
    {
        User? Login(LoginUserViewModel viewModel);
        UserResult Register(RegisterUserViewModel viewModel);
    }
}