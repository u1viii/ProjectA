namespace ProjectA.Core.Entities
{
    public class OrderCategory
    {
        public int Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid CategoryId { get; set; }
        public Order? Order { get; set; }
        public Category? Category { get; set; }
    }
}
