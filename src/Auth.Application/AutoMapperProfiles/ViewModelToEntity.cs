using Auth.Application.ViewModels;
using Auth.Domain.Entities;
using AutoMapper;

namespace Auth.Application.AutoMapperProfiles
{
    public class ViewModelToEntity : Profile
    {
        public ViewModelToEntity()
        {
            CreateMap<RegisterUserViewModel, User>()
                .ForMember(user => user.Name, opt => opt.MapFrom(viewModel => viewModel.Email));
        }
    }
}
