using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestAPI.Controllers
{
    [RoutePrefix("api/departments")]
    [Authorize]
    public class DepartmentController : ApiController
    {
        private readonly IDepartementService _departementService;

        public DepartmentController(IDepartementService departementService)
        {
            _departementService = departementService;
        }

        [Route("")]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            try
            {
                var users = _departementService.GetAll();
                return Ok(users);
            }
            catch (Exception x)
            {
                return InternalServerError(x);
            }
        }


    }
}
