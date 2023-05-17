using ProjectA.Core.Entities.Identity;

namespace ProjectA.Core.Entities
{
    public class AppUserCategory
    {
        public int Id { get; set; }
        public Guid AppUserId { get; set; }
        public Guid CategoryId { get; set; }
        public AppUser? AppUser{ get; set; }
        public Category? Category{ get; set; }
    }
}
