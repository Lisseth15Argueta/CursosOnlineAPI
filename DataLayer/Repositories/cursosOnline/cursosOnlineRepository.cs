using DataLayer.Repositories.DbConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories.cursosOnline
{
    public class CursosOnlineRepository : ICursosOnlineRepository
    {
        private readonly IGenericCRUDRepository _dbConnection;
        private readonly string _collection = "cursosOnline";

        public CursosOnlineRepository(IGenericCRUDRepository dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task AddCursosOnline(CursosOnline cursosOnline)
        {
            await _dbConnection.InsertAsync(_collection, cursosOnline);
        }

        public async Task DeleteAsync(string id)
        {
            await _dbConnection.DeleteAsync<CursosOnline>(_collection, id);
        }


        public async Task UpdateAsync(CursosOnline cursosOnline, string id)
        {
            await _dbConnection.UpsertAsync(_collection, cursosOnline, id);
        }

        public async Task<List<CursosOnline>> GetAllAsync()
        {
            return await _dbConnection.GetAllAsync<CursosOnline>(_collection);
        }

        public async Task<CursosOnline> GetCursosOnlineById(string id)
        {
            return await _dbConnection.GetByIdAsync<CursosOnline>(_collection, id);
        }
    }

    public class CursosOnline
    {
    }
}


