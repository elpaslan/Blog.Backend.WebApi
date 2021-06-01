using System;
using System.Collections.Generic;
using System.Text;
using Dto.Abstract;

namespace Dto.DTOs.CategoryDtos
{
    public class CategoryUpdateDto:IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
