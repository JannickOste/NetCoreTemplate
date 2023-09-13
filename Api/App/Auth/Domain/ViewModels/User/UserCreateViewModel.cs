using System.ComponentModel.DataAnnotations;
using App.Core.Domain.Mappers.Entity;

namespace App.Auth.Domain.ViewModels.User;

[SetEntityRemapper(mapTo: typeof(App.Auth.Domain.User.User))]
public class UserCreateViewModel 
{
    [Required]
    [MinLength(4)]
    [MaxLength(16)]
    public string Username { get; set; } = String.Empty;

    [Required]
    [RegularExpression("^[a-z]+( [a-z]+){1,4}$")]
    public string Name { get; set; } = String.Empty;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = String.Empty;

    [Required]
    public DateTime DateOfBirth { get; set; }
}