using Adesso.WordLeague.Data;
using Adesso.WordLeague.Entities;
using Adesso.WordLeague.Repository.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace Adesso.WordLeague.Repository
{
    public class TeamRepository : ITeamRepository
    {
        private readonly DataContext _dataContext;

        public TeamRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<int> CreateAsync(Team team)
        {
            await _dataContext.AddAsync(team);
            return await _dataContext.SaveChangesAsync();
        }

        public async Task<ICollection<Team>> GetAllAsync()
        {
            return await _dataContext.Set<Team>().ToListAsync();

            //var teams = new List<Team> {
            //    new Team(){Name="Adesso İstanbul",CountryId=1,Id=1},
            //    new Team(){Name="Adesso Ankara",CountryId=1,Id=2},
            //    new Team(){Name="Adesso İzmir",CountryId=1,Id=3},
            //    new Team(){Name="Adesso Antalya",CountryId=1,Id=4},
            //    new Team(){Name="Adesso Berlin",CountryId=2,Id=5},
            //    new Team(){Name="Adesso Frankfurt",CountryId=2,Id=6},
            //    new Team(){Name="Adesso Münih",CountryId=2,Id=7},
            //    new Team(){Name="Adesso Dortmund",CountryId=2,Id=8},
            //    new Team(){Name="Adesso Paris",CountryId=3,Id=9},
            //    new Team(){Name="Adesso Marsilya",CountryId=3,Id=10},
            //    new Team(){Name="Adesso Nice",CountryId=3,Id=11},
            //    new Team(){Name="Adesso Lyon",CountryId=3,Id=12},
            //    new Team(){Name="Adesso Amsterdam",CountryId=4,Id=13},
            //    new Team(){Name="Adesso Rotterdam",CountryId=4,Id=14},
            //    new Team(){Name="Adesso Lahey",CountryId=4,Id=15},
            //    new Team(){Name="Adesso Eindhoven",CountryId=4,Id=16},
            //    new Team(){Name="Adesso Lisbon",CountryId=5,Id=17},
            //    new Team(){Name="Adesso Porto",CountryId=5,Id=18},
            //    new Team(){Name="Adesso Braga",CountryId=5,Id=19},
            //    new Team(){Name="Adesso Coimbra",CountryId=5,Id=20},
            //    new Team(){Name="Adesso Roma",CountryId=6,Id=21},
            //    new Team(){Name="Adesso Milano",CountryId=6,Id=22},
            //    new Team(){Name="Adesso Venedik",CountryId=6,Id=23},
            //    new Team(){Name="Adesso Napoli",CountryId=6,Id=24},
            //    new Team(){Name="Adesso Sevilla",CountryId=7,Id=25},
            //    new Team(){Name="Adesso Madrid",CountryId=7,Id=26},
            //    new Team(){Name="Adesso Barselona",CountryId=7,Id=27},
            //    new Team(){Name="Adesso Granada",CountryId=7,Id=28},
            //    new Team(){Name="Adesso Brüksel",CountryId=8,Id=29},
            //    new Team(){Name="Adesso Brugge",CountryId=8,Id=30},
            //    new Team(){Name="Adesso Gent",CountryId=8,Id=31},
            //    new Team(){Name="Adesso Anvers",CountryId=8,Id=32}
            //};

            //return teams;
        }
    }
}
