namespace App.Core.Domain.Mappers.Entity;
public interface IEntityRemapper<Source, Destination> where Source : class 
                                                          where Destination : class
{
    Destination Remap(Source source);
    Destination Copy(Source source, Destination destination);
}