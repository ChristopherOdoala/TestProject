using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestProject.Repository;
using TestProject.Shared.Resources;

namespace TestProject.Controllers
{
    public class BaseApiController : ControllerBase
    {
        ISampleRepository _repo;

        public BaseApiController(ISampleRepository repo)
        {
            _repo = repo;
        }

        protected ISampleRepository TheRepository
        {
            get
            {
                return _repo;
            }
        }

        public IActionResult ApiResponse<T>(T data = default(T), string message = "", ApiResponseCodes codes = ApiResponseCodes.OK) where T : class
        {
            ApiResponse<T> response = new ApiResponse<T>
            {
                Description = message,
                Payload = data,
                Code = codes
            };
            return Ok(response);
        }

        protected IActionResult HandleError(Exception ex, string customErrorMessage = null)
        {
            ApiResponse<string> rsp = new ApiResponse<string>();
            rsp.Code = ApiResponseCodes.ERROR;
#if DEBUG
            rsp.Description = $"Error: {(ex?.InnerException?.Message ?? ex.Message)} --> {ex?.StackTrace}";
            return Ok(rsp);
#else
             rsp.Description = customErrorMessage ?? "An error occurred while processing your request!";
             return Ok(rsp);
#endif
        }
    }
}