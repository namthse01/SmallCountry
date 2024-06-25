namespace CountryAPI.DTO
{
    public class CreateTownFromCommunesDTO
    {
        public string TownName  { get; set; }
        public List<Guid> CommuneIds { get; set; } = new List<Guid>();
    }
}
