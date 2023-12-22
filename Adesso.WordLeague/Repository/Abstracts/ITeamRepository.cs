using Adesso.WordLeague.Entities;

namespace Adesso.WordLeague.Repository.Abstracts
{
    public interface ITeamRepository
    {
        Task<int> CreateAsync(Team team);

        Task<ICollection<Team>> GetAllAsync();
    }
}
