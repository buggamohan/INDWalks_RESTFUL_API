using INDWalks.API.Model.Domain;

namespace INDWalks.API.Repositories
{
    public interface IRegionRepository
    {
        Task<List<Regions>> GetAllAsync();

        Task<Regions?> GetByIdAsync(int id);

        Task<Regions> CreateAsync(Regions region);

        Task<Regions?> UpdateAsync(int id,Regions region);

        Task<Regions?> DeleteAsync(int id);
    }
}
