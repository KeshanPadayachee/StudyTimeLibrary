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
    public class SemesterWorker
    {

        // Method to add the semester details to the database
        public static void addNewSemesterDetail(DateTime startDate, int numWeeks)
        {
            Models.STUDYTIMEContext connection = new Models.STUDYTIMEContext();
            Models.Semester semester = new Models.Semester();

            semester.StudentId = ListHandler.currentStudent.StudentId;
            semester.NumWeeks = numWeeks;
            semester.StartDate = startDate;


            connection.Add(semester);
            connection.SaveChanges();

            setSemesterDetails();
        }

        // Method to store the users semester details in the List Handler class
        public static void setSemesterDetails()
        {
            Models.STUDYTIMEContext connection = new Models.STUDYTIMEContext();
            ListHandler.currentSemester = connection.Semesters.Where(x => x.StudentId.Equals(ListHandler.currentStudent.StudentId)).First();
        }

        // Method to update the users semester details
        public static void updateSemesterDetails(DateTime startDate, int numWeeks)
        {
            Models.STUDYTIMEContext connection = new Models.STUDYTIMEContext();
            Models.Semester semester = connection.Semesters.Where(x => x.StudentId.Equals(ListHandler.currentStudent.StudentId)).First();

            semester.StartDate = startDate;
            semester.NumWeeks = numWeeks;

            connection.Update(semester);
            connection.SaveChanges();
        }

        // Method to delete the modules for the semester
        public static void deleteModules()
        {
            Models.STUDYTIMEContext connectionDelete = new Models.STUDYTIMEContext();
            Models.Module module = new Models.Module();

            List<Models.Module> userModules = connectionDelete.Modules.Where(x => x.StudentId.Equals(ListHandler.currentStudent.StudentId)).ToList();
            foreach (Models.Module deleteModule in userModules)
            {
                List<Models.StudyRecord> userRecords = connectionDelete.StudyRecords.Where(x => x.ModuleId.Equals(deleteModule.ModuleId)).ToList();
                foreach (Models.StudyRecord deleteRecord in userRecords )
                {
                    connectionDelete.Remove(deleteRecord);
                    connectionDelete.SaveChanges();
                }
                connectionDelete.Remove(deleteModule);
                connectionDelete.SaveChanges();
            }


        }
    }
}
