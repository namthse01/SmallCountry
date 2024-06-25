namespace CountryAPI.DTO
{
    public class GroupCommunesToTownDTO
    {
        public Guid TownId {  get; set; }
        public List<Guid> CommuneIds { get; set; } = new List<Guid>();
    }
}
