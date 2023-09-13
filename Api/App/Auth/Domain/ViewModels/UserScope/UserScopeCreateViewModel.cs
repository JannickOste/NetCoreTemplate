namespace App.Auth.Domain.ViewModels.UserScope;

using System.ComponentModel.DataAnnotations;

public class UserScopeCreateViewModel 
{
    [Required]
    public string Name {get; set;} = String.Empty;
}