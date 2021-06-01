using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICategoryService:IGenericService<Category>
    {
        Task<List<Category>> GetAllWithCategoryBlogsAsync();
    }
}
