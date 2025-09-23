using Company_Disc_Api.Models;
using Company_Disc_Api.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Company_Disc_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private IDepartmentsRepository _repository;

        public DepartmentsController(IDepartmentsRepository repository)
        {
            _repository = repository;
        }

        // GET: api/<MembersController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<IEnumerable<Department>> Get()
        {
            int a = _repository.GetAll().Count;
            List<Department> listOfDepartments = _repository.GetAll();
            if (listOfDepartments.Count < 1)
            {
                return NoContent();
            }
            return Ok(listOfDepartments);
        }

        // GET api/<MembersController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Department> Get(int id)
        {
            Department? foundDepartment = _repository.GetById(id);
            if (foundDepartment == null)
            {
                return NotFound();
            }
            return Ok(foundDepartment);
        }
    }
}
