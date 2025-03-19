using Microsoft.EntityFrameworkCore;
using VerstaTestTask.Domain;

namespace VerstaTestTask.Repo;

public class Repository<T> : IRepository<T> where T : Entity
{
    private readonly AppDbContext _db;
    private readonly DbSet<T> _entities;

    public Repository(AppDbContext db)
    {
        _db = db;
        _entities = _db.Set<T>();
    }

    public void Add(T entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));
        _entities.Add(entity);
        SaveChanges();
    }

    public async Task AddAsync(T entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));
        await _entities.AddAsync(entity);
        await SaveChangesAsync();
    }

    public List<T> GetAll()
    {
        return _entities.ToList();
    }

    public T GetById(Guid id)
    {
        return _entities.Find(id)!;
    }

    public async Task<T> GetByIdAsync(Guid id)
    {
        return (await _entities.FindAsync(id))!;
    }

    public void SaveChanges()
    {
        _db.SaveChanges();
    }

    public async Task SaveChangesAsync()
    {
        await _db.SaveChangesAsync();
    }
}
