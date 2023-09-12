
namespace App.Core.Domain.Entities.User;

public interface IUser 
{
    int Id {get; set;}
    string Username {get; set; }
    string Name {get; set; }
    string Email {get; set;}
    UserScope UserScope {get; set;}
    DateTime DateOfBirth {get; set;}
    bool EmailConfirmed {get; set;}
}