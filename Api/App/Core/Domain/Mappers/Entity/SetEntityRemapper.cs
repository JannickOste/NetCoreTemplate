namespace App.Core.Domain.Mappers.Entity;

public class SetEntityRemapperAttribute : Attribute, IMapperGenerator
{
    private readonly Type mapToType;
    public Type MapToType { get => this.mapToType; }

    public SetEntityRemapperAttribute(Type mapTo)
    {
        this.mapToType = mapTo;
    }
}