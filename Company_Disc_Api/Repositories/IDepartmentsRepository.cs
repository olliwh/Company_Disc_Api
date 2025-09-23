using Company_Disc_Api.Models;

namespace Company_Disc_Api.Repositories
{
    public interface IDepartmentsRepository
    {
        List<Department> GetAll(int? amount = null, string? namefilter = null, int? minLevel = null);
        Department? GetById(int id);
    }
}