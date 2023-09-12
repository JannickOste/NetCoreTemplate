namespace NetCore.Domain.Mappers.ViewModels;

public class EntityCreateViewMapTargetAttribute : Attribute, IMapperGenerator
{
    private readonly Type mapToType;
    public Type MapToType { get => this.mapToType; }

    public EntityCreateViewMapTargetAttribute(Type mapTo)
    {
        this.mapToType = mapTo;
    }
}