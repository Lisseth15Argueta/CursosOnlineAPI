using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Feedback
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string CourseId { get; set; } // Relación con Course
        public string UserId { get; set; } // Relación con User
        public int Rating { get; set; } // Ejemplo: 1 a 5
        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}
