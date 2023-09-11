namespace NetCore.Domain.Mappers.ViewModels;

public interface IEntityCreateMapper<Source, Destination> where Source : class 
                                                          where Destination : class
{
    Destination Map(Source source);
}