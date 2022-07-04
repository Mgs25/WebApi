using Email_WebAPI.Data;
using Email_WebAPI.Models;
using Email_WebAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Email_WebAPI.Controllers;

[ApiController]
[Route("Auth/")]
public class AuthController: ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly IUserRepository _userRepo;
    public AuthController(ApplicationDbContext context, IUserRepository userRepo)
    {
        _context  = context;
        _userRepo = userRepo;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterDTO user)
    {
        return Ok();
    }
}