using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectA.Core.Entities
{
    public class ProjectFile:BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Path { get; set; } = null!;
        public string? Storage { get; set; }
        [NotMapped]
        public override DateTime? UpdatedTime { get; set; }
    }
}
