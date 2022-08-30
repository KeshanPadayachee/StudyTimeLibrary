using System;
using System.Collections.Generic;

#nullable disable

namespace StudyTimeLibrary.Models
{
    public partial class Semester
    {
        public int SemesterId { get; set; }
        public DateTime StartDate { get; set; }
        public int NumWeeks { get; set; }
        public int StudentId { get; set; }

        public virtual Student Student { get; set; }
    }
}
