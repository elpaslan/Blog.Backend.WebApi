using System;
using System.Collections.Generic;
using System.Text;
using Dto.DTOs.CategoryBlogDtos;
using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Validators;

namespace Business.ValidationRules.FluentValidation
{
    public class CategoryBlogValidator:AbstractValidator<CategoryBlogDto>
    {
        public CategoryBlogValidator()
        {
            RuleFor(x => x.CategoryId).InclusiveBetween(0, int.MaxValue);

            RuleFor(x => x.BlogId).InclusiveBetween(0, int.MaxValue);

        }
    }
}
