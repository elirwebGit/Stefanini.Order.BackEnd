namespace Stefanini.Order.Domain.Entites
{
    public class Order: Entity
    {
        public string? CustomerName { get; private set; }
        public string? CustomerEmail { get; private set; }
        public DateTime CreateAt { get; private set; }
        public bool Paid { get; private set; }
        public List<OrderItems> OrderItem { get; private set; } = new List<OrderItems>();

        public Order()
        {

        }

        public Order(string customerName,string customerEmail, bool paid, List<OrderItems> orderItems)
        {
            CustomerName = customerName;
            CustomerEmail = customerEmail;
            Paid = paid;
            CreateAt = DateTime.Now;
        }
    }
}
