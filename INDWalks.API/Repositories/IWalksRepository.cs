using INDWalks.API.Model.Domain;

namespace INDWalks.API.Repositories
{
    public interface IWalksRepository
    {
        Task<List<Walks>> GetAllAsync(string? filterOn=null,string? filterQuery=null,string? sortBy=null,bool IsAcending=true,int pageNumber=1,int pageSize=10);

        Task<Walks?> GetByIdAsync(int id);

        Task<Walks> createAsync(Walks walk);

        Task<Walks?> updateAsync(int id,Walks walk);

        Task<Walks?> DeleteAsync(int id);
    }
}
