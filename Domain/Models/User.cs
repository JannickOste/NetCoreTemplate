

using Microsoft.EntityFrameworkCore;
using NetCore.Domain.Data;

namespace NetCore.Domain.Models;

[RepositoryTarget]
[PrimaryKey("Id")]
public class User : IUser
{
    public int Id {get; set;}
    public string Username { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string UserScope { get; set; } = "User";
    public DateTime DateOfBirth { get; set; }
    public bool EmailConfirmed { get; set; }
}