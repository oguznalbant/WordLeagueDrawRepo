namespace Adesso.WordLeague.Entities
{
    public class Country
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Team> Teams { get; set; }
        public List<Draw> Draws { get; set; }
    }
}
