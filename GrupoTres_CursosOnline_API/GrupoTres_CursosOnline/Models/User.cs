using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoTres_CursosOnline.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name cannot be longer than 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [StringLength(200, ErrorMessage = "Email cannot be longer than 200 characters.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Role is required.")]
        [StringLength(50, ErrorMessage = "Role cannot be longer than 50 characters.")]
        public string Role { get; set; }

        [Required(ErrorMessage = "Courses are required.")]
        public List<CourseEnrollment> Courses { get; set; } = new List<CourseEnrollment>();
    }

    public class CourseEnrollment
    {
        [BsonRepresentation(BsonType.ObjectId)]
        [Required(ErrorMessage = "CourseId is required.")]
        public ObjectId? CourseId { get; set; }

        [Required(ErrorMessage = "EnrollmentDate is required.")]
        [DataType(DataType.Date, ErrorMessage = "Invalid date format.")]
        public string EnrollmentDate { get; set; }
    }
}
