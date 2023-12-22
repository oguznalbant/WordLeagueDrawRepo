using Adesso.WordLeague.Entities;

namespace Adesso.WordLeague.Repository.Abstracts
{
    public interface IDrawRepository
    {
        Task<int> CreateAsync(Draw draw);
    }
}
