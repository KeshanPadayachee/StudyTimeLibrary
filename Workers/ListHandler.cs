// Keshan Padayachee
// 20121106
// PROG 6212
// Portfolio Of Evidence
// Task 2
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyTimeLibrary
{
    public class ListHandler
    {
        // Lists to store the students module information
        public static List<Models.Module> lstModule = new List<Models.Module>();

        // A list to store the students study records
        public static List<Models.StudyRecord> lstStudyRecord = new List<Models.StudyRecord>();

        // Object for current user
        public static Models.Student currentStudent;

        // Object for users semester
        public static Models.Semester currentSemester;
    }
}
