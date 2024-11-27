using GrupoTres_CursosOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoTres_CursosOnline.Repositories.Users
{
    public interface IUserRepository
    {
        Task AddUser(User user);
        Task DeleteAsync(string id);
        Task UpdateAsync(User user, string id);
        Task<List<User>> GetAllAsync(); 
        Task<User> GetUserById(string id);
    }
}
