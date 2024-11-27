using GrupoTres_CursosOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoTres_CursosOnline.Repositories.Modules
{
    public interface IModuleRepository
    {
        Task AddModule(Module module);
        Task DeleteAsync(string id);
        Task UpdateAsync(Module module, string id);
        Task<List<Module>> GetAllAsync();
        Task<Module> GetModuleById(string id);
    }
}
