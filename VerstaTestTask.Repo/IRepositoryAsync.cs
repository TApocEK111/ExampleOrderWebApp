using VerstaTestTask.Domain;

namespace VerstaTestTask.Repo;

public interface IRepositoryAsync<T> where T : Entity
{
    public Task<T> GetByIdAsync(Guid id);
    public Task AddAsync(T entity);
    public Task SaveChangesAsync();
}
