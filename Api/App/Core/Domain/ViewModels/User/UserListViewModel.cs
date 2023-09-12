using App.Core.Domain.Entities.User;

namespace App.Core.Domain.ViewModels.User;

public class UserListViewModel
{
    public IEnumerable<IUser> Users {get; set;} = new List<IUser>();
}