using GrupoTres_CursosOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoTres_CursosOnline.Repositories.Enrollments
{
    public interface IEnrollmentRepository
    {
        Task AddEnrollment(Enrollment enrollment);
        Task DeleteEnrollment(string id);
        Task UpdateEnrollment(Enrollment enrollment, string id);
        Task<List<Enrollment>> GetAllAsync();
        Task<Enrollment> GetEnrollmentById(string id);
    }
}
