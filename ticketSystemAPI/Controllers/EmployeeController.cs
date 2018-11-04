using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ticketSystemAPI_Models; //De namespace van de models
using restserver_paginator;
using ExtensionMethods;

namespace employee_Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ticketSystemContext _context;

        public EmployeeController (ticketSystemContext context)
        {
            _context = context;
        }


        // GET api/Employee
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return _context.Employee.ToList ();
        }

        [HttpGet("GetEmployeesPaged/{page_index}/{page_size}")]
        public IActionResult GetAllEmployees(int page_index, int page_size)
        {
            var res = _context.Employee.GetPage<Employee>(page_index, page_size, a => a.ID);
            if (res == null) return NotFound();

            return Ok(res);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Employee Get(int id)
        {
            return _context.Employee.Find(id);
        }

        // POST api/values
        [HttpPost]
        public StatusCodeResult Post([FromBody] Employee newEmployee)
        {
            try
            {
                _context.Add(newEmployee);
                _context.SaveChanges();
                return Ok();
            } 
            catch 
            {
                return BadRequest();
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
