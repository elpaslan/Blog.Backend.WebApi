using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace WebApi.Model
{
    public class BlogAddModel
    {
        public int AppUserId { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public IFormFile Image { get; set; }
    }
}
