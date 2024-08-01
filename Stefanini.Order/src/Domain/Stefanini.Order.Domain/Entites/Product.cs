namespace Stefanini.Order.Domain.Entites
{
    public class Product: Entity
    {
        public string? ProductName { get;  set; }
        public decimal Value { get; set; }

        public OrderItem OrderItems { get; set; } = null!;

        public Product()
        {

        }
    }
}