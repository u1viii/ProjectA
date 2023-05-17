namespace ProjectA.Core.Entities
{
    public class OrderFile:ProjectFile
    {
        public Guid OrderId { get; set; }
        public Order Order { get; set; }
    }
}
