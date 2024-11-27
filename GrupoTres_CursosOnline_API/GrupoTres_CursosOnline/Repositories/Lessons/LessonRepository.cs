using GrupoTres_CursosOnline.Models;
using GrupoTres_CursosOnline.Repositories.DbConnection;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoTres_CursosOnline.Repositories.Lessons
{
    public class LessonRepository : ILessonRepository
    {
        private readonly IGTCOConnection _dbConnection;
        private readonly string _collection = "lessons"; // La colección de lecciones

        public LessonRepository(IGTCOConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        // Método para agregar una nueva lección
        public async Task AddLesson(Lesson lesson)
        {
            await _dbConnection.InsertAsync(_collection, lesson);
        }

        // Método para eliminar una lección por su ID
        public async Task DeleteAsync(string id)
        {
            await _dbConnection.DeleteAsync<Lesson>(_collection, id);
        }

        // Método para actualizar una lección
        public async Task UpdateAsync(Lesson lesson, string id)
        {
            await _dbConnection.UpsertAsync(_collection, lesson, id);
        }

        // Método para obtener todas las lecciones
        public async Task<List<Lesson>> GetAllAsync()
        {
            return await _dbConnection.GetAllAsync<Lesson>(_collection);
        }

        // Método para obtener una lección por su ID
        public async Task<Lesson> GetLessonById(string id)
        {
            return await _dbConnection.GetByIdAsync<Lesson>(_collection, id);
        }
    }
}
