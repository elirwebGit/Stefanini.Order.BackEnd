using Stefanini.Order.Application.Request;

namespace Stefanini.Order.Application.Mapper
{
    public static class ViewModelToDomain
    {
        public static Domain.Entites.Order Order(OrderRequest orderRequest) 
        {
            return new Domain.Entites.Order(orderRequest.CustomerName!,orderRequest.CustomerEmail!);
        }

        
    }
}
