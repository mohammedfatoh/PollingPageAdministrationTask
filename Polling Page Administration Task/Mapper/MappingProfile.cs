using AutoMapper;
using Polling_Page_Administration_Task.Models;
using Polling_Page_Administration_Task.ViewModels;

namespace Polling_Page_Administration_Task.Mapper
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<ApplicationUser, RegisterUserViewModel>().ReverseMap();
        }
    }
}
