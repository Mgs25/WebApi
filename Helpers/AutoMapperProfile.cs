using AutoMapper;
using Email_WebAPI.Models;

namespace Email_WebAPI.Helpers;

public class UserProfile: Profile
{
    public UserProfile()
    {
        CreateMap<RegisterDTO, User>();
        CreateMap<LoginDTO, User>();
    }
}