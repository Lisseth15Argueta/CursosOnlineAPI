using GrupoTres_CursosOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoTres_CursosOnline.Repositories.Courses
{
    public interface ICourseRepository
    {
        Task AddCourse(Course course);
        Task DeleteAsync(string id);
        Task UpdateAsync(Course course, string id);
        Task<List<Course>> GetAllAsync();
        Task<Course> GetCourseById(string id);

    }
}
