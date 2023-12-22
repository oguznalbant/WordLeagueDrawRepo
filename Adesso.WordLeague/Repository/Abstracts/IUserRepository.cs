using Adesso.WordLeague.Entities;

namespace Adesso.WordLeague.Repository.Abstracts
{
    public interface IUserRepository
    {
        Task<bool> CreateAsync(User user);
    }
}
