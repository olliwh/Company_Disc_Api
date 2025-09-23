using Company_Disc_Api.Models;
using Company_Disc_Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Company_Disc_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private IEmployeesRepository _repository;

        public EmployeesController(IEmployeesRepository repository)
        {
            _repository = repository;
        }

        // GET: api/<MembersController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<IEnumerable<Employee>> Get()
        {
            int a = _repository.GetAll().Count;
            List<Employee> listOfEmployees = _repository.GetAll();
            if (listOfEmployees.Count < 1)
            {
                return NoContent();
            }
            return Ok(listOfEmployees);
        }

        // GET api/<MembersController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Employee> Get(int id)
        {
            Employee? foundEmployee = _repository.GetById(id);
            if (foundEmployee == null)
            {
                return NotFound();
            }
            return Ok(foundEmployee);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Employee> Post([FromBody] Employee newEmployee)
        {
            try
            {
                Employee createdEmployee = _repository.Add(newEmployee);
                int a = _repository.GetAll().Count;
                return Created($"api/Employee/{createdEmployee.Id}", createdEmployee);
            }
            catch (Exception ex) when (ex is ArgumentNullException ||
                                                   ex is ArgumentOutOfRangeException ||
                                                   ex is ArgumentException)
            {
                return BadRequest(ex.InnerException);
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Employee> Put(int id, [FromBody] Employee newData)
        {
            try
            {
                Employee? updated = _repository.Update(id, newData);
                if (updated == null) return NotFound();
                return Ok(updated);
            }
            catch (Exception ex) when (ex is ArgumentNullException ||
                                                   ex is ArgumentOutOfRangeException ||
                                                   ex is ArgumentException)
            {
                return BadRequest(ex.InnerException);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Employee> Delete(int id)
        {
            Employee? deleted = _repository.Delete(id);
            if (deleted == null) return NotFound();
            return Ok(deleted);
        }
    }
}
