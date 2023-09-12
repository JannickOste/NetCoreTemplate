using App.Core.Domain.Database;

namespace App.Core.Domain.Entities.User;

[DbEntity]
public interface IUserScope 
{
    int Id{get; set;}
    string Name {get; set;}
}