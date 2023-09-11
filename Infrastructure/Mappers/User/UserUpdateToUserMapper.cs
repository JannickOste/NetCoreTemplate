using AutoMapper;
using NetCore.Domain.ViewModels.User;

namespace NetCore.Infrastructure.Mapper;

public class UserUpdateToUserMapper
{
    private static readonly AutoMapper.Mapper mapper = new(new MapperConfiguration(
      cfg => cfg.CreateMap<UserUpdateViewModel, Domain.Models.User.User>().ForAllMembers(
          prop => prop.Condition(
              (source, dest, sourceMember) => sourceMember is not null
          )
      )
  ));

    public static Domain.Models.User.User Map(
        Domain.Models.User.User source,
        UserUpdateViewModel userCreateViewModel
    ) => mapper.Map(userCreateViewModel, source);
}