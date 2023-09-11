using AutoMapper;
using NetCore.Domain.Mappers.ViewModels;
namespace NetCore.Infrastructure.Mappers.ViewModels;


public class EntityCreateMapper<Source, Destination> : IEntityCreateMapper<Source, Destination> where Source : class
                                                                                                where Destination : class
{    
    private readonly AutoMapper.Mapper mapper = new(new MapperConfiguration(
        cfg => cfg.CreateMap<Source, Destination>()
    ));

    public virtual Destination Map(Source source)
        => mapper.Map<Destination>(source);
}