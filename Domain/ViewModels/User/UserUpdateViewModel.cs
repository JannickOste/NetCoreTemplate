using System.ComponentModel.DataAnnotations;
using NetCore.Domain.Mappers.ViewModels;

namespace NetCore.Domain.ViewModels.User;

[EntityUpdateViewMapTarget(typeof(NetCore.Domain.Models.User.User))]
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
