using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dto.DTOs.BlogDtos;
using Dto.DTOs.CategoryDtos;
using Dto.DTOs.CommentDtos;
using Entities.Concrete;
using WebApi.Model;

namespace WebApi.Mapping.AutoMapperProfile
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<BlogListDtos, Blog>();
            CreateMap<Blog, BlogListDtos>();

            CreateMap<BlogUpdateModel, Blog>();
            CreateMap<Blog, BlogUpdateModel>();

            CreateMap<BlogAddModel, Blog>();
            CreateMap<Blog, BlogAddModel>();

            CreateMap<CategoryListDto, Category>();
            CreateMap<Category, CategoryListDto>();

            CreateMap<CategoryAddDto, Category>();
            CreateMap<Category, CategoryAddDto>();

            CreateMap<CategoryUpdateDto, Category>();
            CreateMap<Category, CategoryUpdateDto>();

            CreateMap<Comment, CommentListDto>();
            CreateMap<CommentListDto, Comment>();

            CreateMap<Comment, CommentAddDto>();
            CreateMap<CommentAddDto, Comment>();
        }
    }
}
