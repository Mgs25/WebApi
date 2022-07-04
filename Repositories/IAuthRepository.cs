using Email_WebAPI.Models;

namespace Email_WebAPI.Repositories;

public interface IAuthRepository
{
    void Register(RegisterDTO request);
    void Login(LoginDTO request);
}