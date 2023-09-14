using App.Core.Domain.Database;

namespace App.Auth.Domain.Models.User;

[DbEntity(typeof(UserScope))]
public class UserScope 
{
    public int Id{get; set;}
    public string Name {get; set;} = String.Empty;
}