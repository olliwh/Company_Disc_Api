using Company_Disc_Api.Models;

namespace Company_Disc_Api.Repositories
{
    public class DiscTypesRepository : IDiscTypesRepository
    {
        private List<DiscType> _discTypes;
        private int _nextId;

        public DiscTypesRepository()
        {
            _nextId = 1;

            _discTypes = new List<DiscType>()
            {
                new DiscType(_nextId++, "Dominance", "008000"),
                new DiscType(_nextId++, "Influence", "FF0000"),
                new DiscType(_nextId++, "Steadiness", "0000FF"),
                new DiscType(_nextId++, "Conscientiousness", "FFFF00"),
            };
        }
        public DiscType? GetById(int id)
        {
            DiscType? discTypes = _discTypes.Find(x => x.Id == id);
            return discTypes;
        }
        public List<DiscType> GetAll(int? amount = null, string? namefilter = null, int? minLevel = null)
        {
            List<DiscType> result = new List<DiscType>(_discTypes);

            return result;
        }
    }
}
