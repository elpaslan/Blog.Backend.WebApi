using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace Business.Tools.JWTTool
{
    public interface IJwtService
    {
        JwtToken GenerateJwt(AppUser appUser);
    }
}
