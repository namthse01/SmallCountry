namespace CountryAPI.DTO
{
    public class CreateDistrictFromTownsDTO
    {
        public string DistrictName { get; set; }
        public List<Guid> TownIds { get; set; } = new List<Guid>();
    }
}
