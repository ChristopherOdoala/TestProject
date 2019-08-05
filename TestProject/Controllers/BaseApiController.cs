using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestProject.Repository;

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
    }
}