using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Concrete;
using Business.Tools.JWTTool;
using Business.Tools.LogTool;
using Business.ValidationRules.FluentValidation;
using DataAccess.Abstract;
using DataAccess.Concrete.EfCore.Context;
using DataAccess.Concrete.EfCore.Repositories;
using Dto.DTOs.AppUserDtos;
using Dto.DTOs.CategoryBlogDtos;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Business.DependencyResolvers.MicrosoftIoC
{
    public static class CustomIoCExtension
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddScoped<BlogContext>();

            services.AddScoped(typeof(IGenericDal<>),typeof(EfGenericRepository<>));
            services.AddScoped(typeof(IGenericService<>), typeof(GenericManager<>));

            services.AddScoped<IBlogService, BlogManager>();
            services.AddScoped<IBlogDal, EfBlogRepository>();

            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICategoryDal, EfCategoryRepository>();

            services.AddScoped<IAppUserService, AppUserManager>();
            services.AddScoped<IAppUserDal, EfAppUserRepository>();

            services.AddScoped<ICommentService, CommentManager>();
            services.AddScoped<ICommentDal, EfCommentRepository>();

            services.AddScoped<IJwtService, JwtManager>();
            services.AddScoped<ICustomLogger, NLogAdapter>();

            services.AddTransient<IValidator<AppUserLoginDto>, AppUserLoginValidator>();
            services.AddTransient<IValidator<CategoryBlogDto>, CategoryBlogValidator>();
        }
    }
}
