using Stefanini.Order.Application.Request;
using Stefanini.Order.Application.Response;

namespace Stefanini.Order.Application.Interfaces
{
    public interface IOrderApp
    {
        Task<OrderResponse> AddOrder(OrderRequest orderRequest);
        Task<OrderResponse> UpdateOrder(int orderId, OrderRequest orderRequest);

        Task<List<JsonResponse>> GetAllOrder();
        Task<OrderResponse> DeleteOrder(int orderId);

    }
}
