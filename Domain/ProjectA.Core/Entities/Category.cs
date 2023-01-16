using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectA.Core.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public Guid? Parent { get; set; }
        [ForeignKey("Parent")]
        public ICollection<Category>? Children { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
