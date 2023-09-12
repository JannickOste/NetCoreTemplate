
using App.Core.Domain.Database;

namespace App.Core.Domain.Entities.User;

[DbEntity]
public class UserScope 
{
    public int Id{get; set;}
    public string Name {get; set;} = String.Empty;
}