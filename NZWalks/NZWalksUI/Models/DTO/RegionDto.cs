namespace NZWalksUI.Models.DTO
{
    public class RegionDto
    {
        //the data we want to expose to the client
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        //nullable
        public string? RegionImageUrl { get; set; }
    }
}
