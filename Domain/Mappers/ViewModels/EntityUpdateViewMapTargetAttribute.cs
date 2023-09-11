namespace NetCore.Domain.Mappers.ViewModels;

public class EntityUpdateViewMapTargetAttribute : Attribute 
{
    private readonly Type mapToType;
    public Type MapToType { get => this.mapToType; }

    public EntityUpdateViewMapTargetAttribute(Type mapTo)
    {
        this.mapToType = mapTo;
    }
}