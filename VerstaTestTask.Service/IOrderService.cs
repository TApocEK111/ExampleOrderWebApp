using VerstaTestTask.Domain;

namespace VerstaTestTask.Service;

public interface IOrderService
{
    public List<Order> GetAll();
    public Order GetById(Guid id);
    public void Add(Order order);
    public Task<Order> GetByIdAsync(Guid id);
    public Task AddAsync(Order order);
}
