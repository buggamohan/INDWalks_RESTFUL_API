using INDWalks.API.Data;
using INDWalks.API.Model.Domain;
using Microsoft.EntityFrameworkCore;

namespace INDWalks.API.Repositories
{
    public class SqlWalksRepository : IWalksRepository
    {

        public INDWalksDbContext dbContext;

        public SqlWalksRepository(INDWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
       

        public async Task<Walks> createAsync(Walks walk)
        {
            await dbContext.Walks.AddAsync(walk);
            await dbContext.SaveChangesAsync();

            return walk;
        }

        public async Task<Walks?> DeleteAsync(int id)
        {
            var walkDomain = dbContext.Walks.FirstOrDefault(x => x.Id == id);
            if (walkDomain == null)
            {
                return null;
            }
            dbContext.Walks.Remove(walkDomain);
           await dbContext.SaveChangesAsync();
            return walkDomain;
        }

        public async Task<List<Walks>> GetAllAsync(string? filterOn=null,string? filterQuery=null, string? sortBy = null, bool isAcending = true,int pageNumber=1,int pageSize=10)
        {
            var walks= dbContext.Walks.Include("Region").Include("Difficulty").AsQueryable();

            //Filtering 

            if(string.IsNullOrWhiteSpace(filterOn)==false && string.IsNullOrWhiteSpace(filterQuery)==false)
            {
                if (filterOn.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    walks=walks.Where(x => x.Name.Contains(filterQuery));
                }
            }
            //sorting
            if(string.IsNullOrWhiteSpace(sortBy)==false)
            {
                if(sortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    walks=isAcending ? walks.OrderBy(x => x.Name) :walks.OrderByDescending(x => x.Name);
                }
               
            }
            //pagination
            var skipResults = (pageNumber - 1) * pageSize;
            return await walks.Skip(skipResults).Take(pageSize).ToListAsync();
        }

        public async Task<Walks?> GetByIdAsync(int id)
        {
            return await dbContext.Walks.FirstOrDefaultAsync(x => x.Id == id);

        }

        public async Task<Walks?> updateAsync(int id, Walks walks)
        {
            var walkDomain = await dbContext.Walks.FirstOrDefaultAsync(x =>x.Id == id);

            if (walkDomain == null)
            {
                return null;
            }
            walkDomain.Name = walks.Name;
            walkDomain.Description=walks.Description;
            walkDomain.WalksImageURL = walks.WalksImageURL;
            walkDomain.RegionId = walks.RegionId;
            walkDomain.DifficultyId = walks.DifficultyId;

           
           await dbContext.SaveChangesAsync();

            return walks;
        }

        
    }
}
