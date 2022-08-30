using System;
using System.Collections.Generic;

#nullable disable

namespace StudyTimeLibrary.Models
{
    public partial class Module
    {
        public Module()
        {
            StudyRecords = new HashSet<StudyRecord>();
        }

        public int ModuleId { get; set; }
        public string ModuleCode { get; set; }
        public string ModuleName { get; set; }
        public int NumberCredits { get; set; }
        public decimal ClassHours { get; set; }
        public int StudentId { get; set; }

        public virtual Student Student { get; set; }
        public virtual ICollection<StudyRecord> StudyRecords { get; set; }
    }
}
