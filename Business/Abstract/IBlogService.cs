using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dto.DTOs.CategoryBlogDtos;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IBlogService:IGenericService<Blog>
    {
        Task<List<Blog>> GetAllSortedByPostedTimeAsync();
        Task AddToCategoryAsync(CategoryBlogDto categoryBlogDto);
        Task RemoveFromCategoryAsync(CategoryBlogDto categoryBlogDto);
        Task<List<Blog>> GetAllByCategoryIdAsync(int categoryId);
        Task<List<Category>> GetCategoriesAsync(int blogId);
        Task<List<Blog>> GetLastFiveAsync();
        Task<List<Blog>> SearchAsync(string searchString);
    }
}
