namespace ProjectA.Core.Entities
{
    public class Order : BaseEntity
    {
        //Product product;
        //DateTime DeadLine;
        public DateTime DeadLine { get; set; }
        public string Name { get; set; } = null!;
        public int Quantity { get; set; }
        public string Unit { get; set; }= null!;
        public string? Color { get; set; }
        public string? Manufacturer { get; set; }
        public string? Note { get; set; }
        public Guid PaymentId { get; set; }
        public ICollection<OrderImageFile>? OrderImageFiles { get; set; }
        public ICollection<OrderDocumentFile>? OrderDocumentFiles { get; set; }
        public Payment? Payment { get; set; }
        public ICollection<OrderCategory>? OrderCategories { get; set; }
    }
}
