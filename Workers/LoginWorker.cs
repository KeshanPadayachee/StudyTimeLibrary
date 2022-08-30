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
    public class LoginWorker
    {
        // Method to check if user exists in the database and log the user in
        public static bool logUserIn(string studentNumber, string password)
        {
            List<Models.Student> lstStudent = new List<Models.Student>();
            Models.STUDYTIMEContext connection = new Models.STUDYTIMEContext();
            lstStudent = connection.Students.Where(x => x.StudentNumber.Equals(studentNumber)).ToList();
            foreach (Models.Student logIn in lstStudent)
            {
                string hash = PasswordManagement.generateHash(password, logIn.PasswordSalt);
                if (logIn.PasswordHash.Equals(hash))
                {
                    ListHandler.currentStudent = connection.Students.Where(x => x.StudentNumber.Equals(studentNumber)).First();

                    return true;
                }
            }
            return false;
        }

        // Method to get the users semester information
        public static void getSemesterDetails(int studentID)
        {
            Models.STUDYTIMEContext connection = new Models.STUDYTIMEContext();
            ListHandler.currentSemester = connection.Semesters.Where(x => x.StudentId.Equals(studentID)).First();
        }

        // Method to check if the user has semester details saved in the database
        public static bool checkSemesterDetails(int studentID)
        {
            Models.STUDYTIMEContext connection = new Models.STUDYTIMEContext();
            if (connection.Semesters.Where(x => x.StudentId.Equals(studentID)).Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
