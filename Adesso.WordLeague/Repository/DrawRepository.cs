using Adesso.WordLeague.Data;
using Adesso.WordLeague.Entities;
using Adesso.WordLeague.Repository.Abstracts;

namespace Adesso.WordLeague.Repository
{
    public class DrawRepository : IDrawRepository
    {
        private readonly DataContext _dataContext;

        public DrawRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<int> CreateAsync(Draw draw)
        {
            await _dataContext.AddAsync(draw);
            return await _dataContext.SaveChangesAsync();
        }
    }
}
