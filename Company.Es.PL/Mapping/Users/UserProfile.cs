using AutoMapper;
using Company.Es.DAL.Models;
using Company.Es.PL.ViewModels.Users;

namespace Company.Es.PL.Mapping.Users
{
    public class UserProfile : Profile
    {
        public UserProfile() 
        {
            CreateMap<ApplicationUser, UserViewModel>().ReverseMap();
        }

    }
}
