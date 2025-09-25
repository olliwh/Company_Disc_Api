using Company_Disc_Api.Models;

namespace Company_Disc_Api.Repositories
{
    public interface IEmployeesRepository
    {
        Employee Add(Employee employee);
        Employee? Delete(int id);
        List<Employee> GetAll(int? departmentFilter);
        Employee? GetById(int id);
        Employee? Update(int id, Employee employee);
    }
}