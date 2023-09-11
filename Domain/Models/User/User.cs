

using Microsoft.EntityFrameworkCore;
using NetCore.Domain.Data;

namespace NetCore.Domain.Models.User;

[RepositoryTarget]
[PrimaryKey("Id")]
public class User : IUser
{
    public int Id {get; set;}
    public string Email { get; set; } = String.Empty;
    public string Hash { get; set; } = String.Empty;

    public string Name { get; set; } = String.Empty;
    public string Username { get; set; } = String.Empty;


    public UserScope UserScope { get; set; } = UserScope.User;
    public DateTime DateOfBirth { get; set; } = DateTime.MinValue;
    public bool EmailConfirmed { get; set; } = false;
}