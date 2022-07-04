using Email_WebAPI.Models;

namespace Email_WebAPI.Repositories;

public interface IUserRepository
{
    IEnumerable<User> GetAll();
    User GetById(int id);
    void Create(RegisterDTO user);
    void Delete(int id);
    void Update(int id, UpdateDTO user);
    public bool CheckUser(int id);
    public bool CheckUser(RegisterDTO user);
}