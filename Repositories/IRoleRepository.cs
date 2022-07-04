using Email_WebAPI.Models;

namespace Email_WebAPI.Repositories;

public interface IRoleRepository
{
    void Create(string roleName);
    void Delete(string roleName);
    bool CheckRole(string roleName);
    Role GetByName(string roleName);
    IEnumerable<Role> GetAll();
    void AddUserToRole(string role, User user);
}