using System.ComponentModel.DataAnnotations;

namespace INDWalks.API.Model.DTO
{
    public class UpdateRegionDto
    {
        [Required]
        [MinLength(3, ErrorMessage = "Code has Min 3 characters")]
        [MaxLength(3, ErrorMessage = "Code has max 3 characters")]
        public String Code { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "name has max 100 characters")]
        public String Name { get; set; }

    }
}
