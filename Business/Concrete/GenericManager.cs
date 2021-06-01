using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Abstract;

namespace Business.Concrete
{
    public class GenericManager<TEntity>:IGenericService<TEntity> where TEntity:class,ITable, new()
    {
        private IGenericDal<TEntity> _genericDal;

        public GenericManager(IGenericDal<TEntity> genericDal)
        {
            _genericDal = genericDal;
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _genericDal.GetAllAsync();
        }

        public async Task<TEntity> FindByIdAsync(int id)
        {
           return await _genericDal.FindByIdAsync(id);
        }

        public async Task AddAsync(TEntity entity)
        {
            await _genericDal.AddAsync(entity);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            await _genericDal.UpdateAsync(entity);
        }

        public async Task RemoveAsync(TEntity entity)
        {
            await _genericDal.RemoveAsync(entity);
        }
    }
}
