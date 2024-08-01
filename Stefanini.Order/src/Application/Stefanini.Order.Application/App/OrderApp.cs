using Stefanini.Order.Application.Interfaces;
using Stefanini.Order.Application.Mapper;
using Stefanini.Order.Application.Request;
using Stefanini.Order.Application.Response;
using Stefanini.Order.Domain.Interfaces;

namespace Stefanini.Order.Application.App
{
    public class OrderApp : IOrderApp
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderItemRepository orderItemRepository;
        private readonly IProductRepository productRepository; 

        public OrderApp(IOrderRepository orderRepository, IOrderItemRepository orderItemRepository, IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            this.orderItemRepository = orderItemRepository;
            this.productRepository = productRepository;
        }

        public async Task<OrderResponse> AddOrder(OrderRequest orderRequest)
        {

            OrderResponse orderResponse = new OrderResponse();
            if (orderRequest.Item != null && orderRequest.Item.Count > 0)
            {
                
                orderRequest.Item.ForEach(item => 
                {
                    var product = productRepository.GetProduct(item.ProductId).Result;

                    if (product == null)
                    {
                        orderResponse.Message = $"Produto Id:{item.ProductId} não encontrado na base de dados";
                        orderResponse.StatusCode = 401;
                        
                    
                    }
                });

                if (string.IsNullOrEmpty(orderResponse.Message)) 
                {
                    orderRequest.Item.ForEach(item =>
                    {
                        var product = productRepository.GetProduct(item.ProductId).Result;
                        var order = _orderRepository.Add(ViewModelToDomain.Order(orderRequest));
                        var finalPrice = (item.Quantity * product.Value);
                        this.orderItemRepository.Add(
                            new Domain.Entites.OrderItem(order.Id, item.ProductId, item.Quantity, finalPrice));
                    });
                
                    orderResponse.StatusCode = 200;
                    
                }

              
            }
            return await Task.FromResult(orderResponse);
        }

        public async Task<OrderResponse> DeleteOrder(int orderId)
        {
            var order = _orderRepository.GetOrderId(orderId).Result;
            OrderResponse orderResponse = new OrderResponse();
            if (order == null)
            {
                orderResponse.Message = $"Pedido:{orderId} não encontrado na base de dados";
                orderResponse.StatusCode = 401;

            }
            else {
                orderResponse.Message = $"Pedido:{orderId} excluido com sucesso";
                _orderRepository.Delete(new Domain.Entites.Order() { Active = false, Id = orderId });
                orderResponse.StatusCode = 200;
            }
            return await Task.FromResult(orderResponse);
        }

        public async Task<List<JsonResponse>> GetAllOrder()
        {
            var result = await _orderRepository.GetOrder();
            List<JsonResponse> response = new List<JsonResponse>();
            result.ForEach(resp => {
                response.Add(new JsonResponse
                {
                    PedidoId = resp.PedidoId,
                    nomeCliente = resp.nomeCliente,
                    emailCliente = resp.emailCliente,
                    pago = resp.pago,
                    valorTotal = resp.valorTotal,
                    Item = new JsonItem {  
                        idProduto = resp.idProduto,
                        ItemId = resp.ItemId,
                        nomeProduto = resp.nomeProduto,
                        quantidade = resp.quantidade,
                        valorUnitario = resp.valorUnitario
                    }
                }) ;
            });

            return response;

        }

        public async Task<OrderResponse> UpdateOrder(int orderId, OrderRequest orderRequest)
        {
            var order = _orderRepository.GetOrder(orderId).Result;
            OrderResponse orderResponse = new OrderResponse();
            if (order == null)
            {
                orderResponse.Message = $"Pedido:{orderId} não encontrado na base de dados";
                orderResponse.StatusCode = 401;

            }
            else {
                _orderRepository.Update(orderId, ViewModelToDomain.Order(orderRequest));
                orderRequest.Item.ForEach(item => {
                    var product = productRepository.GetProduct(item.ProductId).Result;
                    decimal finalPrice = (item.Quantity * product.Value);
                    var itemId = order.Select(it => it.ItemId).FirstOrDefault();
                    orderItemRepository.Update(itemId, ViewModelToDomain.OrderItems(orderId, item, finalPrice));

                });
                orderResponse.Message = $"Pedido:{orderId} atualizado com sucesso";
                orderResponse.StatusCode = 200;
            }
            return await Task.FromResult(orderResponse);
        }
    }
}
