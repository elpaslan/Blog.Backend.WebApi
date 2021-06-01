using System;
using System.Collections.Generic;
using System.Text;
using Dto.Abstract;

namespace Dto.DTOs.AppUserDtos
{
    public class AppUserDto:IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
    }
}
