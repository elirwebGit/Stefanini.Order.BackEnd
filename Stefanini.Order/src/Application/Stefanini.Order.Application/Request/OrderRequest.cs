namespace Stefanini.Order.Application.Request
{
    public class OrderRequest
    {
        public string? CustomerName { get;  set; }
        public string? CustomerEmail { get;  set; }
        public List<ItemRequest> Item { get; set; } = new List<ItemRequest>();

    }

    public class ItemRequest {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public int Quantity { get; set; }

    }
}
