using NetCore.Domain.Models.User;

namespace NetCore.Domain.ViewModels.User;

public class UserListViewModel
{
    public IEnumerable<IUser> Users {get; set;} = new List<IUser>();
}