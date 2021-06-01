using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EfCore.Repositories;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CategoryManager:GenericManager<Category>,ICategoryService
    {
        private readonly IGenericDal<Category> _genericDal;
        private readonly ICategoryDal _categoryDal;
        public CategoryManager(IGenericDal<Category> genericDal, ICategoryDal categoryDal) : base(genericDal)
        {
            _genericDal = genericDal;
            _categoryDal = categoryDal;
        }

        public async Task<List<Category>> GetAllWithCategoryBlogsAsync()
        {
            return await _categoryDal.GetAllWithCategoryBlogsAsync();
        }
    }
}
