using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectA.Core.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public Guid? Parent { get; set; }
        [ForeignKey("Parent")]
        public List<Category>? Children { get; set; }

        public List<Product> Products { get; set; }
    }
}
