using GrupoTres_CursosOnline.Models;
using GrupoTres_CursosOnline.Repositories.DbConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoTres_CursosOnline.Repositories.Modules
{
    public class ModuleRepository : IModuleRepository
    {
        private readonly IGTCOConnection _dbConnection;
        private readonly string _collection = "modules"; // La colección de módulos

        public ModuleRepository(IGTCOConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        // Método para agregar un nuevo módulo
        public async Task AddModule(Module module)
        {
            await _dbConnection.InsertAsync(_collection, module);
        }

        // Método para eliminar un módulo por su ID
        public async Task DeleteAsync(string id)
        {
            await _dbConnection.DeleteAsync<Module>(_collection, id);
        }

        // Método para actualizar un módulo
        public async Task UpdateAsync(Module module, string id)
        {
            await _dbConnection.UpsertAsync(_collection, module, id);
        }

        // Método para obtener todos los módulos
        public async Task<List<Module>> GetAllAsync()
        {
            return await _dbConnection.GetAllAsync<Module>(_collection);
        }

        // Método para obtener un módulo por su ID
        public async Task<Module> GetModuleById(string id)
        {
            return await _dbConnection.GetByIdAsync<Module>(_collection, id);
        }
    }
}
