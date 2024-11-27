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
    public class Module
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [Required(ErrorMessage = "CourseId is required.")]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId CourseId { get; set; }

        [Required(ErrorMessage = "Module title is required.")]
        [StringLength(200, ErrorMessage = "Module title cannot be longer than 200 characters.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Lessons are required.")]
        public List<Lesson> Lessons { get; set; } = new List<Lesson>();
    }
}
