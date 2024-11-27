using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoTres_CursosOnline.Repositories.DbConnection
{
    public interface IGTCOConnection
    {
        Task DeleteAsync<T>(string table, string id);
        Task<List<T>> GetAllAsync<T>(string table);
        Task<T> GetByIdAsync<T>(string table, string id);
        Task InsertAsync<T>(string table, T record);
        Task UpsertAsync<T>(string table, T record, string id);
    }
}
