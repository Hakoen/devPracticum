using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ticketSystemAPI.Models; //De namespace van de models

namespace ticketSystemAPI.Controllers
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

        // GET api/values/5
        [HttpGet("{id}")]
        public Employee Get(int id)
        {
            return _context.Employee.Find(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
            Employee piet = new Employee(_ssn, name, company)
            retrun _context.Add(piet);
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
