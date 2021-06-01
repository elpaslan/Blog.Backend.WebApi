using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Tools.LogTool;
using Microsoft.AspNetCore.Diagnostics;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ErrorController : ControllerBase
    {
        private readonly ICustomLogger _customLogger;
        public ErrorController(ICustomLogger customLogger)
        {
            _customLogger = customLogger;
        }

        [HttpGet]
        public IActionResult Error()
        {
            var errorInfo= HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            _customLogger.LogError($"\nHatanın oluştuğu yer:{errorInfo.Path}\n Hata Mesajı : {errorInfo.Error.Message} \n Stack Trace: {errorInfo.Error.StackTrace}");
            return Problem(detail: "bir hata olustu, en kisa zamanda fixlenecek");
        }
    }
}
