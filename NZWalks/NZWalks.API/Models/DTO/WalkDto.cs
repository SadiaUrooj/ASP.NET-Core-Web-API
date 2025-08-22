namespace NZWalks.API.Models.DTO
{
    public class WalkDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double lengthInKm { get; set; }
        public string? WalkImageUrl { get; set; }



        public RegionDTO Region { get; set; }
        public DifficultyDto Difficulty { get; set; }
    }
}
