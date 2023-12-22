﻿namespace Adesso.WordLeague.Entities
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }

        public Country Country { get; set; }
        public List<Draw> Draws { get; set; }
    }
}
