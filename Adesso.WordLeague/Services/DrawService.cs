using Adesso.WordLeague.DTO;
using Adesso.WordLeague.Entities;
using Adesso.WordLeague.Models;
using Adesso.WordLeague.Repository.Abstracts;
using Adesso.WordLeague.Services.Abstracts;
using AutoMapper;
using Newtonsoft.Json;

namespace Adesso.WordLeague.Services
{
    public class DrawService : IDrawService
    {
        private readonly ITeamRepository _teamRepository;
        private readonly IDrawRepository _drawRepository;
        private readonly IMapper _mapper;

        public DrawService(ITeamRepository teamRepository, IMapper mapper, IDrawRepository drawRepository)
        {
            _teamRepository = teamRepository;
            _mapper = mapper;
            _drawRepository = drawRepository;
        }

        public async Task<ServiceResponse<DrawDto>> CreateDrawAsync(CreateDrawDto createDrawDto)
        {
            ServiceResponse<DrawDto> response = new();

            try
            {
                var getTeams = await _teamRepository.GetAllAsync();

                if (getTeams == null)
                {
                    response.IsSuccess = false;
                    response.Message = "NotFound";
                    response.Data = null;
                    return response;
                }

                var teams = getTeams.ToList();

                Dictionary<string, List<Team>> drawDictionary;
                char groupName = 'A';
                List<int> notSelectableCountryIds = new List<int>();

                teams = teams.ToList();
                drawDictionary = new Dictionary<string, List<Team>>(createDrawDto.GroupCount);

                // head members and team names
                for (int i = 0; i < createDrawDto.GroupCount; i++)
                {
                    var selectedTeam = GetNextTeam(teams, notSelectableCountryIds);
                    drawDictionary.Add((groupName++).ToString(), new List<Team> { selectedTeam });
                    notSelectableCountryIds.Add(selectedTeam.CountryId);
                    teams.Remove(selectedTeam);
                }

                // other team draw
                for (int i = 0; i < drawDictionary.Count; i++)
                {
                    var groupKey = drawDictionary.ElementAt(i).Key;

                    var countryIdsOfGroupMembers = drawDictionary[groupKey].Select(t => t.CountryId).ToList();
                    var selectedTeam = GetNextTeam(teams, countryIdsOfGroupMembers);

                    drawDictionary[groupKey].Add(selectedTeam);
                    teams.Remove(selectedTeam);

                    if (teams.Count != 0 && i == (drawDictionary.Count - 1))
                    {
                        i = -1;
                    }
                }



                var result = new DrawDto();

                foreach (var group in drawDictionary)
                {
                    result.Groups.Add(new GroupDto() { Name = group.Key, Teams = _mapper.Map<List<TeamDto>>(group.Value.ToList()) });

                    foreach (var team in group.Value.ToList())
                    {
                        await _drawRepository.CreateAsync(new Draw()
                        {
                            CountryId = team.CountryId,
                            CreatedDate = System.DateTime.Now,
                            GroupName = group.Key,
                            TeamId = team.Id,
                            User = new User
                            {
                                FirstName = createDrawDto.UserFirstName,
                                LastName = createDrawDto.UserLastName
                            },
                        });
                    }

                }

                result.User = new UserDto { FirstName = createDrawDto.UserFirstName, LastName = createDrawDto.UserLastName };

                response.Data = result;
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Data = null;
                response.Message = ex.Message;
            }

            return response;
        }

        private Team GetNextTeam(List<Team> getSelectable, List<int> notSelectableCountryIds)
        {
            getSelectable = getSelectable.Where(t => !notSelectableCountryIds.Contains(t.CountryId)).ToList();
            var random = new Random();

            int index = 0;
            if (getSelectable.Count != 0)
            {
                index = random.Next(0, getSelectable.Count - 1);

            }
            return getSelectable.ElementAt(index);
        }
    }
}
