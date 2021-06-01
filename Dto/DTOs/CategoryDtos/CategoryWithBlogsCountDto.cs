using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace Dto.DTOs.CategoryDtos
{
    public class CategoryWithBlogsCountDto
    {
        public int BlogsCount { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
