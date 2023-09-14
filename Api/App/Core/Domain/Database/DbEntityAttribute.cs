using System.Collections.Immutable;

namespace App.Core.Domain.Database;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class DbEntityAttribute : Attribute {
    private static List<Type> targetModels = new List<Type>();
    public static ImmutableList<Type> TargetModels { get => targetModels.ToImmutableList();}

    public DbEntityAttribute(Type type)
    {
        targetModels.Add(type);
    }
}