using GrupoTres_CursosOnline.Models;
using GrupoTres_CursosOnline.Repositories.DbConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoTres_CursosOnline.Repositories.Courses
{
    public class CourseRepository : ICourseRepository
    {
        private readonly IGTCOConnection _dbConnection;
        private readonly string _collection = "courses"; // La colección de cursos

        public CourseRepository(IGTCOConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        // Método para agregar un nuevo curso
        public async Task AddCourse(Course course)
        {
            await _dbConnection.InsertAsync(_collection, course);
        }

        // Método para eliminar un curso por su ID
        public async Task DeleteAsync(string id)
        {
            await _dbConnection.DeleteAsync<Course>(_collection, id);
        }

        // Método para actualizar un curso
        public async Task UpdateAsync(Course course, string id)
        {
            await _dbConnection.UpsertAsync(_collection, course, id);
        }

        // Método para obtener todos los cursos
        public async Task<List<Course>> GetAllAsync()
        {
            return await _dbConnection.GetAllAsync<Course>(_collection);
        }

        // Método para obtener un curso por su ID
        public async Task<Course> GetCourseById(string id)
        {
            return await _dbConnection.GetByIdAsync<Course>(_collection, id);
        }
    }
}
