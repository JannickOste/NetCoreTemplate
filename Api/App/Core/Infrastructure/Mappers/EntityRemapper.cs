using App.Core.Domain.Mappers.Entity;
using AutoMapper;
namespace App.Core.Infrastructure.Mappers;


public class EntityRemapper<Source, Destination> : IEntityRemapper<Source, Destination> where Source : class
                                                                                                where Destination : class
{    
    private readonly Mapper remapper = new(new MapperConfiguration(
        cfg => cfg.CreateMap<Source, Destination>()
    ));

    private static readonly Mapper mapper = new(new MapperConfiguration(
      cfg => cfg.CreateMap<Source, Destination>().ForAllMembers(
          prop => prop.Condition(
              (source, dest, sourceMember) => sourceMember is not null
          )
      )
  ));


    public Destination Copy(Source source, Destination destination)
        => remapper.Map(source, destination);
        
    public virtual Destination Remap(Source source)
        => mapper.Map<Destination>(source);
}