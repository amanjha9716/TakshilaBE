using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace takshBE.Model
{
    public class Student
    {
        [Key]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public string Studname { get; set; }

        public int? Age { get; set; }

        public DateTime? Doj { get; set; }

        public int Stand { get; set; }

        public string? Image { get; set; }

        public List<string>? Subjects { get; set; } // Array of subjects
    }
}
