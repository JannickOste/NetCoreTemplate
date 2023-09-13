namespace App.Core.Domain.Mappers.Entity;
public interface IEntityRemapper<Source, Destination> : IMapper where Source : class 
                                                          where Destination : class 
{
    Destination Remap(Source source);
    Destination Copy(Source source, Destination destination);
}