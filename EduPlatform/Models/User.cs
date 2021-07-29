using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EduPlatform.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public  string FirstName { get; set; }
        public  string MiddleName { get; set; }
        public  string LastName { get; set; }
        public  int Age { get; set; }
        public  string Img { get; set; }
        public  string PhoneNumber { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public List<Course> courses { get; set; } = new List<Course>();
}
}
