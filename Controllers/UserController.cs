using Email_WebAPI.Data;
using Email_WebAPI.Models;
using Email_WebAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Email_WebAPI.Controllers;

[ApiController]
[Route("api")]
public class UserController : ControllerBase
{
    private readonly IUserRepository _userRepo;
    public UserController(IUserRepository userRepo)
    {
        _userRepo = userRepo;
    }

    [HttpGet("Users")]
    public IActionResult GetAll()
    {
        var users = _userRepo.GetAll();
        return Ok(users);
    }

    [HttpGet("User/{id}")]
    public IActionResult GetById(int id)
    {
        try
        {
            var result = _userRepo.GetById(id);
            return Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost("User")]
    public IActionResult Create(RegisterDTO user)
    {
        try
        {
            _userRepo.Create(user);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
        return Ok("User created");
    }

    [HttpDelete("User/{id}")]
    public IActionResult Delete(int id)
    {
        try
        {
            _userRepo.Delete(id);
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }
        return Ok("User deleted");
    }

    [HttpPut("Users/{id}")]
    public IActionResult Update(int id, UpdateDTO user)
    {
        try
        {
            _userRepo.Update(id, user);
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }
        return Ok("User updated");
    }
}