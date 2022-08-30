using System;
using System.Collections.Generic;

#nullable disable

namespace StudyTimeLibrary.Models
{
    public partial class StudyRecord
    {
        public int RecordId { get; set; }
        public int ModuleId { get; set; }
        public DateTime DateStudied { get; set; }
        public decimal HoursStudied { get; set; }

        public virtual Module Module { get; set; }
    }
}
