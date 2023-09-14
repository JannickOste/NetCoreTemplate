using App.Core.Domain.Database;

namespace App.Auth.Domain.Models.User;

public interface IUserScope 
{
    int Id{get; set;}
    string Name {get; set;}
}