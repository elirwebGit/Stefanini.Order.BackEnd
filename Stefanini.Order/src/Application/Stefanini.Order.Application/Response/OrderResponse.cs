using System.Text.Json.Serialization;

namespace Stefanini.Order.Application.Response
{
    public class OrderResponse
    {
        public string? CustomerName { get; set; }
        public string? CustomerEmail { get; set; }
        public bool Paid { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public OrderResponse()
        {

        }
    }

    public class JsonResponse
    {
        public int PedidoId { get; set; }
        public string? nomeCliente { get; set; }
        public string? emailCliente { get; set; }
        public bool? pago { get; set; }
        public decimal valorTotal { get; set; }

        public JsonItem Item { get; set; }= new JsonItem();

    }

    public class JsonItem {
        public int ItemId { get; set; }
        public int idProduto { get; set; }
        public string? nomeProduto { get; set; }
        public decimal valorUnitario { get; set; }
        public int quantidade { get; set; }
    }
}
