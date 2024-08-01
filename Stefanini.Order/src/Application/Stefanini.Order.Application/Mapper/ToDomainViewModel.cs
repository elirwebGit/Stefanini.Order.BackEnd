using Stefanini.Order.Application.Request;
using Stefanini.Order.Application.Response;
using System.Reflection.Metadata.Ecma335;

namespace Stefanini.Order.Application.Mapper
{
    public static class ToDomainViewModel
    {
        public static Response.OrderResponse Order(List<Domain.Entites.Order> order)
        {
            throw new Exception(); 
        }
    }
}
