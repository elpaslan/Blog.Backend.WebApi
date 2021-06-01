using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;
using DataAccess.Concrete.EfCore.Context;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EfCore.Repositories
{
    public class EfBlogRepository:EfGenericRepository<Blog>,IBlogDal
    {
        private readonly BlogContext _context;

        public EfBlogRepository(BlogContext context):base(context)
        {
            _context = context;
        }

        public async Task<List<Blog>> GetAllByCategoryIdAsync(int categoryId)
        {
           
            //sql de inner join sorgularına çalış
         return await  _context.Blogs.Join(_context.CategoryBlogs, b => b.Id, cb => cb.BlogId, (blog, categoryBlog) => new
            {
                blog = blog,
                categoryBlog = categoryBlog
            }).Where(x => x.categoryBlog.CategoryId == categoryId).Select(x => new Blog
            {
                AppUser = x.blog.AppUser,
                AppUserId = x.blog.AppUserId,
                CategoryBlogs = x.blog.CategoryBlogs,
                Comments = x.blog.Comments,
                Description = x.blog.Description,
                Id = x.blog.Id,
                ImagePath = x.blog.ImagePath,
                PostedTime = x.blog.PostedTime,
                ShortDescription = x.blog.ShortDescription,
                Title = x.blog.Title
            }).ToListAsync();
        }

        public async Task<List<Category>> GetCategoriesAsync(int blogId)
        {
           
            return await _context.Categories.Join(_context.CategoryBlogs, c => c.Id, cb => cb.CategoryId, (category, categoryBlog) =>
                new
                {
                    category = category,
                    categoryBlog = categoryBlog
                }).Where(x => x.categoryBlog.BlogId == blogId).Select(x => new Category
            {
                Id = x.category.Id,
                Name = x.category.Name
            }).ToListAsync();
        }

        public async Task<List<Blog>> GetLastFiveAsync()
        {
           
            return await _context.Blogs.OrderByDescending(x => x.PostedTime).Take(5).ToListAsync();
        }
    }
}
