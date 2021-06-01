using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dto.DTOs.AppUserDtos;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IAppUserService:IGenericService<AppUser>
    {
        Task<AppUser> CheckUserAsync(AppUserLoginDto appUserLoginDto);
        Task<AppUser> FindByNameAsync(string userName);
    }
}
