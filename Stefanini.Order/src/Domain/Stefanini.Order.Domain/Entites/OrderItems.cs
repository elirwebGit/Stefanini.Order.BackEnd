namespace Stefanini.Order.Domain.Entites
{
    public class OrderItems: Entity
    {
        public int OrderId { get; private set; }
        public Order Order { get; set; } = null!;
        public int ProductId { get; private set; }
        public Product Product { get; set; } = null!;
        public int Quantity { get; private set; }

        public OrderItems()
        {

        }

        public OrderItems(int productId,int quantity,int orderId)
        {
            ProductId = productId;
            Quantity = quantity;
            OrderId = orderId;
        }
    }
}
