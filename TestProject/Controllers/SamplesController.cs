using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TestProject.Model;
using TestProject.Model.ViewModel;
using TestProject.Repository;
using TestProject.Services;

namespace TestProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SamplesController : BaseApiController
    {
        IFileUploadService _service;
        public SamplesController(ISampleRepository repo, IFileUploadService service)
            :base(repo)
        {
            _service = service;
        }

        [HttpGet]
        [Route("")]

        public object Get()
        {
            try
            {
                var result = TheRepository.GetAllSampleData();
                if (result.Count() <= 0)
                    return NoContent();

                return result;
            }
            catch(Exception ex)
            {
                return HandleError(ex);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public object Get(int id)
        {
            try
            {
                var result = TheRepository.GetSampleData(id);
                if (result == null)
                    return BadRequest("Record does not exist");

                return result;
            }
            catch (Exception ex)
            {
                return HandleError(ex);
            }
        }

        [HttpPost]
        [Route("")]
        public IActionResult Post([FromBody]SampleViewModel model)
        {
            SampleModel sample = new SampleModel
            {
                name = model.name,
                note = model.note
            };

            if(sample == null)
                return BadRequest(ApiResponse<string>(message: "No data found"));
            try
            {
                if(TheRepository.Insert(sample) && TheRepository.SaveAll())
                {
                    return Created("Successfully Created",sample);
                }
            }
            catch(Exception ex)
            {
                //TODO Logging
                return HandleError(ex);
            }

            return BadRequest(ApiResponse<string>(message: "Something went wrong"));
        }

        [HttpPost]
        [Route("update/{id}")]
        public IActionResult Update([FromBody]SampleViewModel model, int id)
        {
            try
            {
                var result = TheRepository.GetSampleData(id);
                if (model == null)
                    return BadRequest(ApiResponse<string>(message: "No data found"));
                result.name = model.name;
                result.note = model.note;

                if(TheRepository.Update(result) && TheRepository.SaveAll())
                {
                    return Ok(ApiResponse<object>(result));
                }
            }
            catch(Exception ex)
            {
                return HandleError(ex);
            }

            return BadRequest(ApiResponse<string>(message: "Something went wrong"));
        }

        [HttpPost]
        [Route("upload")]
        public IActionResult Upload([FromBody] FileUploadModel model)
        {
            var res = _service.Upload(model);
            if (res)
                return Ok();
            else
                return BadRequest();
        }
    }
}