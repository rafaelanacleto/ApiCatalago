using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalago.Dtos
{
    public class RevokeTokenModel
    {
        public string UserId { get; set; }
        public string RefreshToken { get; set; }

    }
}