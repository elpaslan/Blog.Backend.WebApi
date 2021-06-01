using System;
using System.Collections.Generic;
using System.Text;
using Dto.Abstract;

namespace Dto.DTOs.BlogDtos
{
    public class BlogListDtos :IDto    
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public DateTime PostedTime { get; set; }
    }
}
