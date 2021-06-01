using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Abstract;
using DataAccess.Concrete.EfCore.Context;
using Entities.Concrete;

namespace DataAccess.Concrete.EfCore.Repositories
{
    public class EfAppUserRepository:EfGenericRepository<AppUser>,IAppUserDal
    {
        private readonly BlogContext _context;

        public EfAppUserRepository(BlogContext context):base(context)
        {
            _context = context;
        }
    }
}
