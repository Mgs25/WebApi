using AutoMapper;
using Email_WebAPI.Data;
using Email_WebAPI.Models;

namespace Email_WebAPI.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly IRoleRepository _roleRepo;

    public UserRepository(ApplicationDbContext context, IMapper mapper, IRoleRepository roleRepo)
    {
        _context  = context;
        _mapper   = mapper;
        _roleRepo = roleRepo;
    }

    public void Create(RegisterDTO user)
    {
        if (_context.Users.Any(x => x.Username == user.Username || x.MailAddress == user.MailAddress))
            throw new Exception("User already exist");
        
        if (!_roleRepo.CheckRole(user.Role))
            throw new Exception("Role does not exist");

        User newUser = new User()
        {
            Username    = user.Username,
            MailAddress = user.MailAddress,
            RoleId = _roleRepo.GetByName(user.Role).Id
        };

        // add user to role

        _roleRepo.AddUserToRole(user.Role, newUser);

        _context.Users.Add(newUser);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        if (!IsValidId(id))
            throw new Exception("Invalid ID");

        var userToDelete = _context.Users.FirstOrDefault(x => x.Id == id);

        if (userToDelete == null)
            throw new Exception("User does not exist");
        
        _context.Users.Remove(userToDelete);
        _context.SaveChanges();
    }

    public IEnumerable<User> GetAll()
    {
        return _context.Users.ToList();
    }

    public User GetById(int id)
    {
        if (!IsValidId(id))
            throw new Exception("Invalid ID");
        
        var user = _context.Users.FirstOrDefault(x => x.Id == id);

        if (user == null)
            throw new Exception("User not found!");
        
        return user;
    }

    public bool CheckUser(int id)
    {
        return _context.Users.Any(x => x.Id == id);
    }

    public bool CheckUser(RegisterDTO user)
    {
        return _context.Users.Any(x => x.Username == user.Username || x.MailAddress == user.MailAddress);
    }

    public void Update(int id, UpdateDTO user)
    {
        if (!IsValidId(id))
            throw new Exception("Invalid ID");

        var userObj = _context.Users.FirstOrDefault(x => x.Id == id);

        if (userObj == null)
            throw new Exception("User not found");
        
        if (user.MailAddress != null)
            userObj.MailAddress = user.MailAddress;
        
        if (user.Username != null)
            userObj.Username = user.Username;
        
        if (_roleRepo.CheckRole(user.Role))
            userObj.RoleId = _roleRepo.GetByName(user.Role).Id;

        _context.Users.Update(userObj);
        _context.SaveChanges();
    }

    private bool IsValidId(int id) {
        return id != null && id > 0;
    }
}