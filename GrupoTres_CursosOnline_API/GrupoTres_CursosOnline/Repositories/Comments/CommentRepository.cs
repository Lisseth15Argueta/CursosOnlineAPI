using GrupoTres_CursosOnline.Models;
using GrupoTres_CursosOnline.Repositories.DbConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoTres_CursosOnline.Repositories.Comments
{
    public class CommentRepository : ICommentRepository
    {
        private readonly IGTCOConnection _dbConnection;
        private readonly string _collection = "comments"; // Colección de comentarios

        public CommentRepository(IGTCOConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        // Método para agregar un comentario
        public async Task AddCommentAsync(Comment comment)
        {
            await _dbConnection.InsertAsync(_collection, comment);
        }

        // Método para eliminar un comentario por su ID
        public async Task DeleteCommentAsync(string id)
        {
            await _dbConnection.DeleteAsync<Comment>(_collection, id);
        }

        // Método para actualizar un comentario
        public async Task UpdateCommentAsync(Comment comment, string id)
        {
            await _dbConnection.UpsertAsync(_collection, comment, id);
        }

        // Método para obtener todos los comentarios
        public async Task<List<Comment>> GetAllCommentsAsync()
        {
            return await _dbConnection.GetAllAsync<Comment>(_collection);
        }

        // Método para obtener un comentario por su ID
        public async Task<Comment> GetCommentByIdAsync(string id)
        {
            return await _dbConnection.GetByIdAsync<Comment>(_collection, id);
        }
    }

}
