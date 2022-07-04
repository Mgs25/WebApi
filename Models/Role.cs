using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace Email_WebAPI.Models;

public class Role
{
    public Role()
    {
        Users = new List<User>();
    }

    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public List<User> Users { get; set; }
}