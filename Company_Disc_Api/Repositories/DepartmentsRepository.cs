

using Company_Disc_Api.Models;

namespace Company_Disc_Api.Repositories
{
    public class DepartmentsRepository : IDepartmentsRepository
    {
        private List<Department> _departments;
        private int _nextId;
        public DepartmentsRepository()
        {
            _nextId = 1;
            _departments = new List<Department>()
            {
                new Department(_nextId++, "HR"),
                new Department(_nextId++, "IT"),
                new Department(_nextId++, "Customer Service"),
                new Department(_nextId++, "Support"),
                new Department(_nextId++, "Reception"),
                new Department(_nextId++, "Finance"),
                new Department(_nextId++, "Marketing"),
            };
        }
        public Department? GetById(int id)
        {
            Department? department = _departments.Find(x => x.Id == id);
            return department;
        }
        public List<Department> GetAll(int? amount = null, string? namefilter = null, int? minLevel = null)
        {
            List<Department> result = new List<Department>(_departments);

            return result;
        }
    }
}
