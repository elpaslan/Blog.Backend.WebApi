using System;
using System.Collections.Generic;
using System.Text;
using Dto.Abstract;

namespace Dto.DTOs.CategoryDtos
{
    public class CategoryAddDto:IDto
    {
        public string Name { get; set; }
    }
}
