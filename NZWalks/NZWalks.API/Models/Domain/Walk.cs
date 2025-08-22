namespace NZWalks.API.Models.Domain
{
    public class Walk
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double lengthInKm { get; set; }
        public string? WalkImageUrl { get; set; }

        //Relationship b/w the walk and region
        public Guid DifficultyId { get; set; }
        public Guid RegionId { get; set; }


        //Navigation properties
        //this will tell the entity framework that the DifficultyId is in the Difficulty
        public Difficulty Difficulty { get; set; }
        //one-to-one relationship b/w walk, reagion and the difficulty
        public Region Region { get; set; }

    }
}
