using System.ComponentModel.DataAnnotations;

namespace INDWalks.API.Model.Domain
{
    public class Regions
    {
        
        public int Id { get; set; }

        

        public String Code { get; set; }

        public String Name { get; set; }

        public String? RegionImageURL { get; set; }
    }
}
