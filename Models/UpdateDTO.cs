using System.ComponentModel.DataAnnotations;

namespace Email_WebAPI.Models;

public class UpdateDTO
{
    public string? Username { get; set; }

    public string? Password { get; set; }
    public string? Role { get; set; }
    [EmailAddress]
    public string? MailAddress { get; set; }
}