using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApi.CustomFilter
{
    public class ValidId<TEntity>:IActionFilter where TEntity:class,ITable, new()
    {
        private readonly IGenericService<TEntity> _genericService;

        public ValidId(IGenericService<TEntity> genericService)
        {
            _genericService = genericService;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
          var dictionary=  context.ActionArguments.FirstOrDefault(x => x.Key == "id");

          var id = int.Parse(dictionary.Value.ToString() ?? string.Empty);

         var entity= _genericService.FindByIdAsync(id).Result;
         if (entity==null)
         {
             context.Result= new NotFoundObjectResult($"{id} değerine sahip nesne bulunamadı");
         }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }
    }
}
