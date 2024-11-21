
namespace DataLayer.Repositories.DbConnection
{
    public interface IGenericCRUDRepository
    {
        Task DeleteAsync<T>(string table, string id);
        Task<List<T>> GetAllAsync<T>(string table);
        Task<T> GetByIdAsync<T>(string table, string id);
        Task InsertAsync<T>(string table, T record);
        Task UpsertAsync<T>(string table, T record, string id);
    }
}