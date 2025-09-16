using INDWalks.API.Model.Domain;

namespace INDWalks.API.Model.DTO
{
    public class WalksDto
    {
        public int Id { get; set; }

        public String Name { get; set; }

        public String Description { get; set; }

        public String? WalksImageURL { get; set; }

     
        

        public RegionDto Region { get; set; }

        public DifficultyDto Difficulty { get; set; }

       

       

    }
}
