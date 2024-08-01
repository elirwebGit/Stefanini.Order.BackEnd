namespace Stefanini.Order.Domain.Dapper
{
    public class OrderList
    {
        public int PedidoId { get; set; }
        public string? nomeCliente { get; set; }
        public string? emailCliente { get; set; }
        public bool? pago { get; set; }
        public decimal valorTotal { get; set; }
        public int ItemId { get; set; }
        public int idProduto { get; set; }
        public string? nomeProduto { get; set; }
        public decimal valorUnitario { get; set; }
        public int quantidade { get; set; }

    }
}
