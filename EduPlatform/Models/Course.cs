using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EduPlatform.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        public string CourseName { get; set; }
        public string Description { get; set; }
        public string Img { get; set; }
        public int Price { get; set; }
        public DateTime AddedDate { get; set; }

        public List<User> users { get; set; } = new List<User>();

        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
    }
}
