using Email_WebAPI.Data;
using Email_WebAPI.Models;

namespace Email_WebAPI.Repositories;

public class RoleRepository: IRoleRepository
{
    private readonly ApplicationDbContext _context;
    public RoleRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public void Create(string roleName)
    {
        if (CheckRole(roleName))
            throw new Exception("Role already exist");
        
        var newRole = new Role()
        {
            Name = roleName
        };

        _context.Roles.Add(newRole);
        _context.SaveChanges();
    }

    public void Delete(string roleName)
    {
        if (!CheckRole(roleName))
            throw new Exception("Role does not exist");
    

        var roleToDelete = _context.Roles.First(x => x.Name == roleName);

        _context.Roles.Remove(roleToDelete);
        _context.SaveChanges();
    }

    public IEnumerable<Role> GetAll()
    {
        return _context.Roles.ToList();
    }


    public bool CheckRole(string roleName)
    {
        return _context.Roles.Any(x => x.Name == roleName);
    }

    public Role GetByName(string roleName)
    {
        if (!CheckRole(roleName))
            throw new Exception("Role does not exist");
        
        return _context.Roles.First(x => x.Name == roleName);
    }

    public void AddUserToRole(string role, User user)
    {
        _context.Roles.First(x => x.Name == role).Users.Add(user);
    }
}