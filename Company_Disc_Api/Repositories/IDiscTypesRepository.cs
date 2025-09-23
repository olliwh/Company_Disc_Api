using Company_Disc_Api.Models;

namespace Company_Disc_Api.Repositories
{
    public interface IDiscTypesRepository
    {
        List<DiscType> GetAll(int? amount = null, string? namefilter = null, int? minLevel = null);
        DiscType? GetById(int id);
    }
}