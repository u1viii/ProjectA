namespace ProjectA.Core.Entities
{
    public class Product : BaseEntity
    {
        public string Title { get; set; }
        public string Detail { get; set; }
        public string Note { get; set; }
        public List<Category> Categories { get; set; }
    }
}
