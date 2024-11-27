using GrupoTres_CursosOnline.Models;
using GrupoTres_CursosOnline.Repositories.DbConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoTres_CursosOnline.Repositories.Enrollments
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        private readonly IGTCOConnection _dbConnection;
        private readonly string _collection = "enrollments"; // La colección de inscripciones

        public EnrollmentRepository(IGTCOConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        // Método para agregar una nueva inscripción
        public async Task AddEnrollment(Enrollment enrollment)
        {
            await _dbConnection.InsertAsync(_collection, enrollment);
        }

        // Método para eliminar una inscripción por su ID
        public async Task DeleteEnrollment(string id)
        {
            await _dbConnection.DeleteAsync<Enrollment>(_collection, id);
        }

        // Método para actualizar una inscripción
        public async Task UpdateEnrollment(Enrollment enrollment, string id)
        {
            await _dbConnection.UpsertAsync(_collection, enrollment, id);
        }

        // Método para obtener todas las inscripciones
        public async Task<List<Enrollment>> GetAllAsync()
        {
            return await _dbConnection.GetAllAsync<Enrollment>(_collection);
        }

        // Método para obtener una inscripción por su ID
        public async Task<Enrollment> GetEnrollmentById(string id)
        {
            return await _dbConnection.GetByIdAsync<Enrollment>(_collection, id);
        }
    }
}
