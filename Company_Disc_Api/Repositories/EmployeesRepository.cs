using Company_Disc_Api.Models;
using System.Xml.Linq;

namespace Company_Disc_Api.Repositories
{
    public class EmployeesRepository : IEmployeesRepository
    {
        private List<Employee> _employees;
        private int _nextId;
        private readonly IDiscTypesRepository _discTypesRepository;
        private readonly IDepartmentsRepository _departmentsRepository;
        private string _baseImgUrl = "Disc_API/Images";

        public EmployeesRepository(IDiscTypesRepository discTypesRepository, IDepartmentsRepository departmentsRepository)
        {
            _nextId = 1;
            _discTypesRepository = discTypesRepository;
            _departmentsRepository = departmentsRepository;

            _employees = new List<Employee>()
            {
                new Employee(_nextId++, "Morten Olsen", "m@m.dk", _departmentsRepository.GetById(1), _discTypesRepository.GetById(1), "https://upload.wikimedia.org/wikipedia/commons/thumb/e/e6/Morten_Olsen_2012_%28cropped%29.jpg/500px-Morten_Olsen_2012_%28cropped%29.jpg"),
                new Employee(_nextId++, "Kanye West", "K@m.dk", _departmentsRepository.GetById(1), _discTypesRepository.GetById(1),"https://upload.wikimedia.org/wikipedia/commons/thumb/c/cd/Kanye_West_Lollapalooza_Chile_2011_2.jpg/500px-Kanye_West_Lollapalooza_Chile_2011_2.jpg"),
                new Employee(_nextId++, "Jay Z", "J@m.dk", _departmentsRepository.GetById(1), _discTypesRepository.GetById(4), "https://upload.wikimedia.org/wikipedia/commons/thumb/9/9c/Jay-Z_%40_Shawn_%27Jay-Z%27_Carter_Foundation_Carnival_%28crop_2%29.jpg/500px-Jay-Z_%40_Shawn_%27Jay-Z%27_Carter_Foundation_Carnival_%28crop_2%29.jpg"),
                new Employee(_nextId++, "Venus Williams", "J@m.dk", _departmentsRepository.GetById(2), _discTypesRepository.GetById(4),   "https://upload.wikimedia.org/wikipedia/commons/thumb/2/2f/Williams_V._RG21_%2811%29_%2851376275968%29_%28cropped%29.jpg/330px-Williams_V._RG21_%2811%29_%2851376275968%29_%28cropped%29.jpg"),
                new Employee(_nextId++, "Daniel Agger", "d@m.dk", _departmentsRepository.GetById(2), _discTypesRepository.GetById(3), "https://upload.wikimedia.org/wikipedia/commons/e/e6/Daniel_Agger_20120613.jpg"),
                new Employee(_nextId++, "Nadia Nadim", "N@m.dk", _departmentsRepository.GetById(3), _discTypesRepository.GetById(3), "https://upload.wikimedia.org/wikipedia/commons/thumb/4/47/Nadia_Nadim_20170803_WEURO_DEN_AUT_1716_%28cropped%29.jpg/500px-Nadia_Nadim_20170803_WEURO_DEN_AUT_1716_%28cropped%29.jpg"),
                new Employee(_nextId++, "Bob Dylan", "B@m.dk", _departmentsRepository.GetById(3), _discTypesRepository.GetById(2),  "https://upload.wikimedia.org/wikipedia/commons/thumb/2/2a/DylanYoungKilkenny140719v2_%2850_of_52%29_%2852246124397%29_%28cropped%29.jpg/500px-DylanYoungKilkenny140719v2_%2850_of_52%29_%2852246124397%29_%28cropped%29.jpg"),
                new Employee(_nextId++, "Lionel Messi", "L@m.dk", _departmentsRepository.GetById(3), _discTypesRepository.GetById(2), "https://upload.wikimedia.org/wikipedia/commons/thumb/c/c1/Lionel_Messi_20180626.jpg/500px-Lionel_Messi_20180626.jpg")
            };
        }
        public Employee? GetById(int id)
        {
            Employee? poke = _employees.Find(x => x.Id == id);
            return poke;
        }
        public Employee Add(Employee employee)
        {
            employee.Id = _nextId++;

            _employees.Add(employee);
            return employee;
        }
        public Employee? Delete(int id)
        {
            Employee? pokeToDelete = GetById(id);
            if (pokeToDelete == null) return null;
            _employees.Remove(pokeToDelete);
            return pokeToDelete;
        }
        public Employee? Update(int id, Employee employee)
        {
            Employee? employeeToUpdate = GetById(id);

            if (employeeToUpdate == null) return null;
            employeeToUpdate.Email = employee.Email;
            employeeToUpdate.Name = employee.Name;
            employeeToUpdate.DiscType = employee.DiscType;
            employeeToUpdate.Department = employee.Department;
            employeeToUpdate.ImgUrl = employee.ImgUrl;
            return employeeToUpdate;
        }
        public List<Employee> GetAll(int? amount = null, string? namefilter = null, int? minLevel = null)
        {
            List<Employee> result = new List<Employee>(_employees);

            return result;
        }
    }
}
