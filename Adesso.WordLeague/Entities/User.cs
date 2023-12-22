namespace Adesso.WordLeague.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<Draw> Draws { get; set; }
    }
}
