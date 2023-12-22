using Adesso.WordLeague.Entities;

namespace Adesso.WordLeague.Repository.Abstracts
{
    public interface ICountryRepository
    {
        Task<bool> CreateAsync(Country country);

        Task<Country> GetAsync(int id);

        Task<ICollection<Country>> GetAllAsync();
    }
}
