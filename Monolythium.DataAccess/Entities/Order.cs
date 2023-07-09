namespace Monolythium.DataAccess.Entities
{
    public class Order
    {
        public int Id { get; set; }

        public decimal TotalAmount { get; set; }

        public string CustomerFullName { get; set; } = null!;

        public OrderStatus Status { get; set; }
    }
}
