using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstract;
using Business.Tools.LogTool;
using Dto.DTOs.CategoryDtos;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using WebApi.CustomFilter;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        
        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(_mapper.Map<List<CategoryListDto>>(await _categoryService.GetAllAsync()));
        }

        [HttpGet("{id}")]
        [ServiceFilter(typeof(ValidId<Category>))]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(_mapper.Map<CategoryListDto>(await _categoryService.FindByIdAsync(id)));
        }

        [HttpPost]
        [Authorize]
        [ValidModel]
        public async Task<IActionResult> Create(CategoryAddDto categoryAddDto)
        {
           await _categoryService.AddAsync(_mapper.Map<Category>(categoryAddDto));
            return Created("",categoryAddDto);
        }

        [HttpPut("{id}")]
        [Authorize]
        [ValidModel]
        [ServiceFilter(typeof(ValidId<Category>))]
        public async Task<IActionResult> Update(int id,CategoryUpdateDto categoryUpdateDto)
        {
            if (id != categoryUpdateDto.Id) return BadRequest("geçersiz id");
            var updatedCategory = await _categoryService.FindByIdAsync(id);
            updatedCategory.Id = categoryUpdateDto.Id;
            updatedCategory.Name = categoryUpdateDto.Name;

            await _categoryService.UpdateAsync(updatedCategory);
            return NoContent();

        }

        [HttpDelete("{id}")]
        [ServiceFilter(typeof(ValidId<Category>))]
        public async Task<IActionResult> Delete(int id)
        {
            await _categoryService.RemoveAsync(await _categoryService.FindByIdAsync(id));
            return NoContent();
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetWithBlogsCount()
        {
            var categories = await _categoryService.GetAllWithCategoryBlogsAsync();
            var listCategory = new List<CategoryWithBlogsCountDto>();

            foreach (var category in categories)
            {
                var dto = new CategoryWithBlogsCountDto
                {
                    CategoryName = category.Name,
                    CategoryId = category.Id,
                    BlogsCount = category.CategoryBlogs.Count
                };

                listCategory.Add(dto);
            }

            return Ok(listCategory);
        }

      
    }
}
