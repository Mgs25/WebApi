using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Email_WebAPI.Models;

public class RegisterDTO
{
    [Required]
    public string? Username { get; set; }

    [Required]
    public string? Password { get; set; }
    [Required]
    
    public string? Role { get; set; }
    [Required]
    [EmailAddress]
    public string? MailAddress { get; set; }
}