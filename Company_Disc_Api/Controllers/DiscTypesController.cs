using Company_Disc_Api.Models;
using Company_Disc_Api.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Company_Disc_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscTypesController : ControllerBase
    {
        private IDiscTypesRepository _repository;
        public DiscTypesController(IDiscTypesRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<IEnumerable<DiscType>> Get()
        {
            int a = _repository.GetAll().Count;
            List<DiscType> listOfDiscTypes = _repository.GetAll();
            if (listOfDiscTypes.Count < 1)
            {
                return NoContent();
            }
            //Thread.Sleep(2000);

            return Ok(listOfDiscTypes);
        }

        // GET api/<MembersController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<DiscType> Get(int id)
        {
            DiscType? foundDiscType = _repository.GetById(id);
            if (foundDiscType == null)
            {
                return NotFound();
            }
            return Ok(foundDiscType);
        }
    }
}
