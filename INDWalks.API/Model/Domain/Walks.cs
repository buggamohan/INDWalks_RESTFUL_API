using System.ComponentModel.DataAnnotations.Schema;

namespace INDWalks.API.Model.Domain
{
    public class Walks
    {
        public int Id { get; set; }

        public String Name { get; set; }

        public String Description { get; set; }

        public String? WalksImageURL  { get; set; }

        public int RegionId { get; set; }

        public int DifficultyId { get; set; }

        [ForeignKey(nameof(RegionId))]
        public Regions Region { get; set; }

        [ForeignKey(nameof(DifficultyId))]
        public Difficulty Difficulty { get; set; }   

    }
}
