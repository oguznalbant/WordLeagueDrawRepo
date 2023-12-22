using Adesso.WordLeague.DTO;
using Adesso.WordLeague.Models;

namespace Adesso.WordLeague.Services.Abstracts
{
    public interface IDrawService
    {
        Task<ServiceResponse<DrawDto>> CreateDrawAsync(CreateDrawDto createDrawDto);
    }
}
