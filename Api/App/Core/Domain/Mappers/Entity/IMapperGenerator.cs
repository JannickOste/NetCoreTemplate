namespace App.Core.Domain.Mappers;
public interface IMapperGenerator : IMapper
{
    System.Type MapToType { get; }
}