using AutoMapper;
using NetCore.Domain.ViewModels.User;

namespace NetCore.Infrastructure.Mapper.User; 

public class UserCreateToUserMapper 
{
    private static readonly AutoMapper.Mapper mapper = new(new MapperConfiguration(
        cfg => cfg.CreateMap<UserCreateViewModel, Domain.Models.User.User>()
    ));

    public static Domain.Models.User.User Map(UserCreateViewModel userCreateViewModel) => mapper.Map<Domain.Models.User.User>(userCreateViewModel);
}