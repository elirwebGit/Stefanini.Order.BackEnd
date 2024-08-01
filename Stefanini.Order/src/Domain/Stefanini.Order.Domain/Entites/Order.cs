namespace Stefanini.Order.Domain.Entites
{
    public class Order: Entity
    {
        public string? CustomerName { get; private set; }
        public string? CustomerEmail { get; private set; }
        public DateTime CreateAt { get; private set; }
        public bool Paid { get; private set; }
        public bool Active { get; set; }
        public List<OrderItem> OrderItem { get; private set; } = new List<OrderItem>();

        public Order()
        {

        }

        public Order(string customerName,string customerEmail)
        {
            CustomerName = customerName;
            CustomerEmail = customerEmail;
            Paid = true;
            Active = true;
              CreateAt = DateTime.Now;
        }

        public Order(string customerName, string customerEmail, List<OrderItem> orderItems)
        {
            CustomerName = customerName;
            CustomerEmail = customerEmail;
            Paid = true;
            Active = true;
            OrderItem = orderItems;
        }
    }
}
