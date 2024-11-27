using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoTres_CursosOnline.Models
{
    public class Comment
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string LessonId { get; set; } // Relación con la lección

        [BsonRepresentation(BsonType.ObjectId)]
        public string UserId { get; set; } // Relación con el usuario que comenta

        [Required(ErrorMessage = "Comment is required.")]
        public string CommentText { get; set; }

        public DateTime Date { get; set; }
    }

}
