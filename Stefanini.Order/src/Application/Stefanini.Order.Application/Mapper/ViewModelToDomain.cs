using Stefanini.Order.Application.Request;

namespace Stefanini.Order.Application.Mapper
{
    public static class ViewModelToDomain
    {
        public static Domain.Entites.Order Order(OrderRequest orderRequest) 
        {
            return new Domain.Entites.Order(orderRequest.CustomerName!,orderRequest.CustomerEmail!);
        }


        public static Domain.Entites.OrderItem OrderItems(int orderId,ItemRequest orderRequest, decimal value)
        {
            Domain.Entites.OrderItem orderItems = new Domain.Entites.OrderItem();
            orderItems = new Domain.Entites.OrderItem(orderId, orderRequest.ProductId, orderRequest.Quantity, value);
              
            return orderItems;
        }
    }
}
