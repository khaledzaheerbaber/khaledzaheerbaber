using Entity.Model;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestAPI.Controllers
{
    [RoutePrefix("api/employees")]
    [Authorize]
    public class EmployeeController : ApiController
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [Route("")]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            try
            {
                var users = _employeeService.GetAll();
                return Ok(users);
            }
            catch (Exception x)
            {
                return InternalServerError(x);
            }
        }


        [Route("{Id}")]
        [HttpGet]
        public IHttpActionResult GetById(Guid Id)
        {
            try
            {
                var user = _employeeService.GetById(Id);
                return Ok(user);
            }
            catch (Exception x)
            {
                return InternalServerError(x);
            }
        }

        [Route("")]
        [HttpPost]
        public IHttpActionResult Post(Employee model)
        {
            try
            {
                _employeeService.Add(model);
                return Ok(true);
            }
            catch (Exception x)
            {
                return InternalServerError(x);
            }
        }


        [Route("")]
        [HttpPut]
        public IHttpActionResult Put(Employee model)
        {
            try
            {
                _employeeService.Update(model);
                return Ok(true);
            }
            catch (Exception x)
            {
                return InternalServerError(x);
            }
        }


        [Route("{Id}")]
        [HttpDelete]
        public IHttpActionResult Delete(Guid Id)
        {
            try
            {
                _employeeService.Delete(Id);
                return Ok(true);
            }
            catch (Exception x)
            {
                return InternalServerError(x);
            }
        }


    }
}
