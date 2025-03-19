using VerstaTestTask.Domain;
using VerstaTestTask.Repo;

namespace VerstaTestTask.Service;

public class OrderService : IOrderService
{
    private readonly IRepository<Order> _orderRepository;

    public OrderService(IRepository<Order> repository)
    {
        _orderRepository = repository;
    }

    public void Add(Order order)
    {
        _orderRepository.Add(order);
    }

    public async Task AddAsync(Order order)
    {
        await _orderRepository.AddAsync(order);
    }

    public List<Order> GetAll()
    {
        return _orderRepository.GetAll();
    }

    public Order GetById(Guid id)
    {
        return _orderRepository.GetById(id);
    }

    public async Task<Order> GetByIdAsync(Guid id)
    {
        return await _orderRepository.GetByIdAsync(id);
    }
}
