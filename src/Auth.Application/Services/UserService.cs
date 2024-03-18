using Auth.Application.Interfaces;
using Auth.Application.Validations;
using Auth.Application.ViewModels;
using Auth.Domain.Entities;
using Auth.Domain.Interfaces;
using AutoMapper;

using static BCrypt.Net.BCrypt;

namespace Auth.Application.Services
{

    public record UserResult(bool Success, IEnumerable<string> ErrorMessages = null);
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository, IMapper mapper, IUnitOfWork uow)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _uow = uow;
        }

        public UserResult Register(RegisterUserViewModel viewModel)
        {
            var validation = new RegisterUserValidation().Validate(viewModel);
            if (!validation.IsValid) return new UserResult(false, validation.Errors.Select(x => x.ErrorMessage));


            bool userExist = _userRepository.GetByEmail(viewModel.Email) != null;
            if (userExist) return new UserResult(false, new List<string> { "User exists" });

            var entity = _mapper.Map<User>(viewModel);

            entity.Password = HashPassword(viewModel.Password);

            _userRepository.Insert(entity);

            bool commit = _uow.SaveChanges();

            if (!commit) return new UserResult(false, new List<string> { "Error update database" });

            return new UserResult(true);

        }

        public User? Login(LoginUserViewModel viewModel)
        {
            var validation = new LoginUserValidation().Validate(viewModel);
            if (!validation.IsValid) return null;

            var user = _userRepository.GetByEmail(viewModel.Email);
            if (user == null) return null;

            bool verify = Verify(viewModel.Password, user.Password);
            if (!verify) return null;

            return user;
        }
    }
}
