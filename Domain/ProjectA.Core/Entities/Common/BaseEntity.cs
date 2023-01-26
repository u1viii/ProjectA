namespace ProjectA.Core.Entities.Common
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public virtual DateTime? CreatedTime { get; set; }
        public virtual DateTime? DeletedTime { get; set; }
    }
}
