using System;
using System.Collections.Generic;

#nullable disable

namespace StudyTimeLibrary.Models
{
    public partial class Student
    {
        public Student()
        {
            Modules = new HashSet<Module>();
            Semesters = new HashSet<Semester>();
        }

        public int StudentId { get; set; }
        public string StudentNumber { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string CellNumber { get; set; }
        public string EmailAddress { get; set; }
        public string PasswordSalt { get; set; }
        public string PasswordHash { get; set; }

        public virtual ICollection<Module> Modules { get; set; }
        public virtual ICollection<Semester> Semesters { get; set; }
    }
}
