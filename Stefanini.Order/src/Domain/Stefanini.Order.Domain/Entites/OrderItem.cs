namespace Stefanini.Order.Domain.Entites
{
    public class OrderItem : Entity
    {
        public int OrderId { get; private set; }
        public Order Order { get; set; } = null!;
        public int ProductId { get; private set; }
        public Product Product { get; set; } = null!;
        public int Quantity { get; private set; }
        public decimal Value { get; private set; }

        public OrderItem()
        {

        }

        public OrderItem(int orderId, int productId,int quantity, decimal value)
        {
            OrderId = orderId;
            ProductId = productId;
            Quantity = quantity;
            Value = value;
        }
    }
}
