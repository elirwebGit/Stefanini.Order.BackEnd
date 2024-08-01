namespace Stefanini.Order.Domain.Interfaces
{
    public interface IOrderRepository
    {
        Task<IEnumerable<string>> GetOrderAsync();
        Task<string> GetByIdAsync(int livroId);
        Task AddAsync(Entites.Order order);
        Task UpdateAsync(Entites.Order order);
    }
}
