namespace CountryAPI.DTO
{
    public class GroupTownsToDistrictDTO
    {
        public Guid DistrictId { get; set; }
        public List<Guid> TownIds { get; set; } = new List<Guid>();
    }
}
