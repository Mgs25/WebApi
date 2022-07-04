using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using Email_WebAPI.Services;

namespace Email_WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class EmailController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly IMailService _mailer;
    public EmailController(IConfiguration configuration, IMailService mailer)
    {
        _configuration = configuration;
        _mailer = mailer;
    }

    [HttpPost("send")]
    public IActionResult SendMail(string to_address, string subject, string body)
    {
        try
        {
            _mailer.Send(to_address, subject, body);
            return Ok("Mail sent successfully");
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);    
        }
    }
}