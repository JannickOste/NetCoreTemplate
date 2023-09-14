namespace App.Core.Domain.Mappers.Entity;
/// <summary>
/// Interface for mapping entities from a source type to a destination type.
/// </summary>
/// <typeparam name="Source">The source entity type.</typeparam>
/// <typeparam name="Destination">The destination entity type.</typeparam>
public interface IEntityRemapper<Source, Destination> : IMapper where Source : class
                                                              where Destination : class
{
    /// <summary>
    /// Maps a source entity to a destination entity.
    /// </summary>
    /// <param name="source">The source entity.</param>
    /// <returns>The mapped destination entity.</returns>
    Destination Remap(Source source);

    /// <summary>
    /// Copies values from the source entity to the destination entity.
    /// </summary>
    /// <param name="source">The source entity.</param>
    /// <param name="destination">The destination entity.</param>
    /// <returns>The destination entity with copied values.</returns>
    Destination Copy(Source source, Destination destination);
}