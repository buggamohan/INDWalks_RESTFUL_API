using INDWalks.API.Data;
using INDWalks.API.Model.Domain;
using Microsoft.EntityFrameworkCore;

namespace INDWalks.API.Repositories
{
    public class SqlRegionRepository : IRegionRepository
    {
        public INDWalksDbContext dbContext;
        public SqlRegionRepository(INDWalksDbContext dbContext) {
            this.dbContext = dbContext;
        }

        public async Task<Regions> CreateAsync(Regions region)
        { 

           await dbContext.Regions.AddAsync(region);
            await dbContext.SaveChangesAsync();

            return region;
        }

        public async Task<Regions?> DeleteAsync(int id)
        {
            var regionDomain= dbContext.Regions.FirstOrDefault(x => x.Id == id);
            if(regionDomain == null)
            {
                return null;
            }
            dbContext.Regions.Remove(regionDomain);
            await dbContext.SaveChangesAsync();
            return regionDomain;
        }

        public async Task<List<Regions>> GetAllAsync()
        {
            return await dbContext.Regions.ToListAsync();
        }

        public async Task<Regions?> GetByIdAsync(int id)
        {
            return await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            

        }

        public async Task<Regions?> UpdateAsync(int id, Regions region)
        {
           var existingRegion= dbContext.Regions.FirstOrDefault(y => y.Id == id);
            if(existingRegion == null)
            {
                return null;
            }
            existingRegion.Code = region.Code;
            existingRegion.Name = region.Name;

            await dbContext.SaveChangesAsync();
            return existingRegion;
        }
    }
}
