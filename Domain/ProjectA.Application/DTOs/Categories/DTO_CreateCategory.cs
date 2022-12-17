using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectA.Application.DTOs.Categories
{
    public class DTO_CreateCategory
    {
        public string? ParentId { get; set; }
        public string Name { get; set; } = null!;
    }
}
