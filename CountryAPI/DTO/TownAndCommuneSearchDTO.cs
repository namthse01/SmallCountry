namespace CountryAPI.DTO
{
    public class TownAndCommuneSearchDTO
    {
        public string? TownName { get; set; }
        public List<string> CommuneName { get; set; } = new List<string>();
    }
}
