namespace App.Core.Domain.Database;

public interface IDatabaseRepository<TEntity> 
{
    /// <summary>
    /// Get a <typeparamref name="TEntity"/> by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the <typeparamref name="TEntity"/>.</param>
    /// <returns>The <typeparamref name="TEntity"/> object if found, or null if not found.</returns>
    TEntity? GetById(int id);

    /// <summary>
    /// Get all <typeparamref name="TEntity"/> objects.
    /// </summary>
    /// <returns>An IEnumerable of <typeparamref name="TEntity"/> objects.</returns>
    IEnumerable<TEntity> GetAll();

    /// <summary>
    /// Insert a new <typeparamref name="TEntity"/> into the database.
    /// </summary>
    /// <param name="entity">The <typeparamref name="TEntity"/> to insert.</param>
    /// <returns>The inserted <typeparamref name="TEntity"/> object.</returns>
    TEntity Insert(TEntity entity);

    /// <summary>
    /// Update an existing <typeparamref name="TEntity"/> in the database.
    /// </summary>
    /// <param name="entity">The <typeparamref name="TEntity"/> to update.</param>
    void Update(TEntity entity);

    /// <summary>
    /// Delete a <typeparamref name="TEntity"/> from the database.
    /// </summary>
    /// <param name="entity">The <typeparamref name="TEntity"/> to delete.</param>
    void Delete(TEntity entity);
}