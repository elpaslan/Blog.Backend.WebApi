using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface ICategoryDal:IGenericDal<Category>
    {
        Task<List<Category>> GetAllWithCategoryBlogsAsync();
    }
}
