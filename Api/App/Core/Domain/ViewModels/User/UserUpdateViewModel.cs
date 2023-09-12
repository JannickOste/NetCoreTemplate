using System.ComponentModel.DataAnnotations;
using App.Core.Domain.Mappers.Entity;

namespace App.Core.Domain.ViewModels.User;
[SetEntityRemapper(mapTo: typeof(App.Core.Domain.Entities.User.User))]
public class UserUpdateViewModel
{
    [MinLength(4)]
    [MaxLength(16)]
    public string? Username { get; set; }

    [RegularExpression("^[a-z]+( [a-z]+){1,4}$")]
    public string? Name { get; set; }

    [EmailAddress]
    public string? Email { get; set; }

    public DateTime DateOfBirth { get; set; }
}
