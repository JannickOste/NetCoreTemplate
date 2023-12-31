
using App.Core.Domain.Database;
using Microsoft.EntityFrameworkCore;
namespace App.Core.Domain.Entities.User;

[DbEntity]
[PrimaryKey("Id")]
public class User : IUser
{
    public int Id {get; set;}
    public string Email { get; set; } = String.Empty;
    public string Hash { get; set; } = String.Empty;

    public string Name { get; set; } = String.Empty;
    public string Username { get; set; } = String.Empty;


    public UserScope UserScope { get; set; }
    public DateTime DateOfBirth { get; set; } = DateTime.MinValue;
    public bool EmailConfirmed { get; set; } = false;
}