using ProjectA.Core.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
