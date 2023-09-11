using System.Collections.Immutable;

namespace NetCore.Domain.ViewModels.User;

public class UserListViewModel
{
    public IEnumerable<IUser> Users {get; set;} = new List<IUser>();
}