using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectA.Core.Entities.Identity
{
    public class AppUser:IdentityUser<Guid>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool? IsMale { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpires { get; set; }
        public string Company { get; set; }
        public string? Position { get; set; }
        public string? TIN { get; set; }
        public bool? IsCustomer { get; set; }
        public bool? IsSupplier { get; set; }
        public ICollection<AppUserCategory> AppUserCategories { get; set; }
    }
}
