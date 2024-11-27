using GrupoTres_CursosOnline.Models;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoTres_CursosOnline.Repositories.Lessons
{
    public interface ILessonRepository
    {
        Task AddLesson(Lesson lesson);
        Task DeleteAsync(string id);
        Task UpdateAsync(Lesson lesson, string id);
        Task<List<Lesson>> GetAllAsync();
        Task<Lesson> GetLessonById(string id);
    }

}
