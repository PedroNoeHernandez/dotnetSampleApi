using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using storeAPIService.Models;

namespace storeAPIService.Interfaces
{
    public interface ITokenService
    {
        string CreateToken (AppUser appUser);
    }
}