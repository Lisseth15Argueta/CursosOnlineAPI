using GrupoTres_CursosOnline.Models;
using GrupoTres_CursosOnline.Repositories.DbConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoTres_CursosOnline.Repositories.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly IGTCOConnection _dbConnection;
        private readonly string _collection = "users"; // La colección de usuarios

        public UserRepository(IGTCOConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        // Método para agregar un nuevo usuario
        public async Task AddUser(User user)
        {
            await _dbConnection.InsertAsync(_collection, user);
        }

        // Método para eliminar un usuario por su ID
        public async Task DeleteAsync(string id)
        {
            await _dbConnection.DeleteAsync<User>(_collection, id);
        }

        // Método para actualizar un usuario
        public async Task UpdateAsync(User user, string id)
        {
            await _dbConnection.UpsertAsync(_collection, user, id);
        }

        // Método para obtener todos los usuarios
        public async Task<List<User>> GetAllAsync()
        {
            return await _dbConnection.GetAllAsync<User>(_collection);
        }

        // Método para obtener un usuario por su ID
        public async Task<User> GetUserById(string id)
        {
            return await _dbConnection.GetByIdAsync<User>(_collection, id);
        }
    }
}
