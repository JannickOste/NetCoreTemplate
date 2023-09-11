using AutoMapper;
using NetCore.Domain.Mappers.ViewModels;
namespace NetCore.Infrastructure.Mappers.ViewModels;

public class EntityUpdateMapper<Source, Destination> : IEntityUpdateMapper<Source, Destination> where Source : class
                                                                                                where Destination : class
{    
    private static readonly AutoMapper.Mapper mapper = new(new MapperConfiguration(
      cfg => cfg.CreateMap<Source, Destination>().ForAllMembers(
          prop => prop.Condition(
              (source, dest, sourceMember) => sourceMember is not null
          )
      )
  ));
    public virtual Destination Map(
        Destination original,
        Source viewModel
    ) => mapper.Map(viewModel, original);
}