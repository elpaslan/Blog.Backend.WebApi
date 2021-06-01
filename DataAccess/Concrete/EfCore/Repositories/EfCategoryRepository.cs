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
    public class EfCategoryRepository:EfGenericRepository<Category>,ICategoryDal
    {
        private readonly BlogContext _context;

        public EfCategoryRepository(BlogContext context):base(context)
        {
            _context = context;
        }
        public async Task<List<Category>> GetAllWithCategoryBlogsAsync()
        {
            return await _context.Categories.OrderByDescending(x=>x.Id).Include(x => x.CategoryBlogs).ToListAsync();

        }
    }
}
