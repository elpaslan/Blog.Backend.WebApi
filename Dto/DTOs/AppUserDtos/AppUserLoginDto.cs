using System;
using System.Collections.Generic;
using System.Text;
using Dto.Abstract;

namespace Dto.DTOs.AppUserDtos
{
    public class AppUserLoginDto:IDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
