using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using DataAccess.Abstract;
using Dto.DTOs.CategoryBlogDtos;
using Entities.Concrete;

namespace Business.Concrete
{
    public class BlogManager : GenericManager<Blog>, IBlogService
    {
        private readonly IGenericDal<Blog> _genericDal;
        private readonly IGenericDal<CategoryBlog> _categoryBlogService;
        private readonly IBlogDal _blogDal;
        public BlogManager(IGenericDal<Blog> genericDal, IGenericDal<CategoryBlog> categoryBlogService, IBlogDal blogDal) : base(genericDal)
        {
            _genericDal = genericDal;
            _categoryBlogService = categoryBlogService;
            _blogDal = blogDal;
        }

        public async Task<List<Blog>> GetAllSortedByPostedTimeAsync()
        {
            return await _genericDal.GetAllAsync(x => x.PostedTime);
        }

        public async Task AddToCategoryAsync(CategoryBlogDto categoryBlogDto)
        {
            var control = await _categoryBlogService.GetAsync(I => I.CategoryId == categoryBlogDto.CategoryId && I.BlogId == categoryBlogDto.BlogId);
            if (control == null)
            {
                await _categoryBlogService.AddAsync(new CategoryBlog
                {
                    BlogId = categoryBlogDto.BlogId,
                    CategoryId = categoryBlogDto.CategoryId
                });
            }
           
        }

        public async Task RemoveFromCategoryAsync(CategoryBlogDto categoryBlogDto)
        {
            var deletedCategoryBlog = await _categoryBlogService.GetAsync(x =>
                  x.CategoryId == categoryBlogDto.CategoryId && x.BlogId == categoryBlogDto.BlogId);
            if (deletedCategoryBlog != null)
            {
                await _categoryBlogService.RemoveAsync(deletedCategoryBlog);
            }

        }

        public async Task<List<Blog>> GetAllByCategoryIdAsync(int categoryId)
        {
            return await _blogDal.GetAllByCategoryIdAsync(categoryId);

        }

        public async Task<List<Category>> GetCategoriesAsync(int blogId)
        {
            return await _blogDal.GetCategoriesAsync(blogId);
        }

        public async Task<List<Blog>> GetLastFiveAsync()
        {
            return await _blogDal.GetLastFiveAsync();
        }

        public async Task<List<Blog>> SearchAsync(string searchString)
        {
            return await _blogDal.GetAllAsync(
                x => x.Title.Contains(searchString) || x.ShortDescription.Contains(searchString) ||
                     x.Description.Contains(searchString), x => x.PostedTime);
        }
    }
}
