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

namespace TestProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SamplesController : BaseApiController
    {
        public SamplesController(ISampleRepository repo)
            :base(repo)
        {

        }

        [HttpGet]
        [Route("")]
        public object Get()
        {
            try
            {
                var result = TheRepository.GetAllSampleData();
                return result;
            }
            catch(Exception ex)
            {
                return ex.Message + " " + ex.StackTrace;
            }
        }

        [HttpGet]
        [Route("{id}")]
        public object Get(int id)
        {
            try
            {
                var result = TheRepository.GetSampleData(id);
                return result;
            }
            catch (Exception ex)
            {
                return ex.Message + " " + ex.StackTrace;
            }
        }

        [HttpPost]
        [Route("")]
        public HttpResponseMessage Post([FromBody]SampleViewModel model)
        {
            SampleModel sample = new SampleModel
            {
                name = model.name,
                note = model.note
            };

            if(sample == null)
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            try
            {
                if(TheRepository.Insert(sample) && TheRepository.SaveAll())
                {
                    return new HttpResponseMessage(HttpStatusCode.Created);
                }
            }
            catch(Exception ex)
            {
                //TODO Logging
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }

            return new HttpResponseMessage(HttpStatusCode.InternalServerError);
        }

        //public static HttpResponseMessage CreateResponse<T>(this HttpRequestMessage requestMessage, HttpStatusCode statusCode, T content)
        //{
        //    return new HttpResponseMessage() { StatusCode = statusCode, Content = new StringContent(JsonConvert.SerializeObject(content))
        //    };
        //}
    }
}