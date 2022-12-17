namespace ProjectA.Core.Entities.Common
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? DeletedTime { get; set; }
    }
}
