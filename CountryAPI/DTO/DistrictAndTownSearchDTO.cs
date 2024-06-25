namespace CountryAPI.DTO
{
    public class DistrictAndTownSearchDTO
    {
        public string? DistrictName { get; set; }
        public List<string> TownName { get; set; } = new List<string>();
    }
}
