namespace App.Auth.Domain.ViewModels.UserScope;
using App.Auth.Domain.Models.User;

public class UserScopeListViewModel 
{
    public IEnumerable<UserScope>? UserScopes{get; set;}
}