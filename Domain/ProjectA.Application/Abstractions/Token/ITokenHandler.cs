using ProjectA.Application.DTOs.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectA.Application.Abstractions.Token
{
    public interface ITokenHandler
    {
        DTO_Token CreateAccessToken(int minute);
    }
}
