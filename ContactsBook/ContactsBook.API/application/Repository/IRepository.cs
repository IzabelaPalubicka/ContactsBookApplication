namespace ContactsBook.API.application.Repository
{
    /// <summary>
    /// Base interface of repository.
    /// </summary>
    /// <typeparam name="T">Type of aggregate.</typeparam>
    public interface IRepository<T>
    {
        /// <summary>
        /// Persists state.
        /// </summary>
        /// <param name="item">Entity.</param>
        /// <returns>Task.</returns>
        Task Persist(T entity);

        /// <summary>
        /// Gets the entity by guid identifier.
        /// </summary>
        /// <param name="id">Identifier of entity.</param>
        /// <returns>Task that gets entity.</returns>
        Task<T?> GetById(int id);
    }
}
