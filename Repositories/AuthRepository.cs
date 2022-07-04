using System.Security.Cryptography;
using Email_WebAPI.Models;
using System.Text;

namespace Email_WebAPI.Repositories;

public class AuthRepository : IAuthRepository
{
    private readonly IUserRepository _userRepo;
    public AuthRepository(IUserRepository userRepo)
    {
        _userRepo = userRepo;
    }
    public void Login(LoginDTO user)
    {
        throw new NotImplementedException();
    }

    public void Register(RegisterDTO request)
    {
        if (_userRepo.CheckUser(request))
            throw new Exception("User already exist");
        
        GenerateHashAndSalt(request.Password, out byte[] PasswordHash, out byte[] PasswordSalt);

        
    }

    private void GenerateHashAndSalt(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        using (var hmac = new HMACSHA256())
        {
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }
    }
}