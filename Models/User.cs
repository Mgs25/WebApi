using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Email_WebAPI.Models;

public class User
{
    [Key]
    public int Id { get; set; }
    public string? Username { get; set; }
    public DateTime createdAt { get; set; } = DateTime.Now.Date;
    [EmailAddress]
    public string? MailAddress { get; set; }
    
    public byte[]? PasswordHash { get; set; }
    public byte[]? PasswordSalt { get; set; }

    [ForeignKey("Role")]
    public int RoleId { get; set; }
}