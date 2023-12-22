namespace Adesso.WordLeague.Entities
{
    public class Draw
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
        public DateTime CreatedDate { get; set; }

        public int UserId { get; set; }
        public int TeamId { get; set; }
        public int CountryId { get; set; }


        public Country Country { get; set; }
        public Team Team { get; set; }
        public User User { get; set; }
    }
}
