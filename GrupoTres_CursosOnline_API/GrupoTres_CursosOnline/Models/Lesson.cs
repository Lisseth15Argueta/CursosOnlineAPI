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
    public class Lesson
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId ModuleId { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [StringLength(200, ErrorMessage = "Lesson title cannot be longer than 200 characters.")]
        public string Title { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Duration must be a positive number.")]
        public int Duration { get; set; } // Duration in minutes

        public string Content { get; set; }

        [BsonDefaultValue(null)]
        public List<Comments> CommentsByUsers { get; set; } = new List<Comments>();
    }

    public class Comments
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId? Id { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId LessonId { get; set; } // Relación con la lección

        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId UserId { get; set; } // Relación con el usuario que comenta

        [Required(ErrorMessage = "Comment is required.")]
        public string CommentText { get; set; }

        public DateTime Date { get; set; }
    }
}
