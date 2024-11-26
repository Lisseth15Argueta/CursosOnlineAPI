
namespace DataLayer.Repositories.cursosOnline
{
    public interface ICursosOnlineRepository
    {
        Task AddCursosOnline(CursosOnline cursosOnline);
        Task DeleteAsync(string id);
        Task<List<CursosOnline>> GetAllAsync();
        Task<CursosOnline> GetCursosOnlineById(string id);
        Task UpdateAsync(CursosOnline cursosOnline, string id);
    }
}