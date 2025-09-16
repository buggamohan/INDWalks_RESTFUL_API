using INDWalks.API.Model.Domain;
using System.ComponentModel.DataAnnotations;

namespace INDWalks.API.Model.DTO
{
    public class AddWalksDto
    {
        [Required]
        [MaxLength(100,ErrorMessage ="Name has max 100 characters")]
        public String Name { get; set; }

        [Required]
        public String Description { get; set; }

        public String? WalksImageURL { get; set; }

        [Required]
        public int RegionId { get; set; }

        [Required]
        public int DifficultyId { get; set; }

       
    }
}
