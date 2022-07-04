using Email_WebAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Email_WebAPI.Controllers;

[ApiController]
[Route("api/")]
public class RoleController: ControllerBase
{
    private readonly IRoleRepository _roleRepo;
    public RoleController(IRoleRepository roleRepo)
    {
        _roleRepo = roleRepo;
    }

    [HttpGet("Roles")]
    public IActionResult GetAll()
    {
        try
        {
            var users = _roleRepo.GetAll();
            return Ok(users);
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost("Role")]
    public IActionResult Create(string roleName)
    {
        try
        {
            _roleRepo.Create(roleName);
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }
        return Ok("Role created successfully");
    }

    [HttpDelete("Role")]
    public IActionResult Delete(string roleName)
    {
        try
        {
            _roleRepo.Delete(roleName);
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }
        return Ok("Role deleted successfully");
    }
}