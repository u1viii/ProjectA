using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectA.Application.RequestParameters
{
    public record Pagination(int Page = 0, int Take = 5);
}
