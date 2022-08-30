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
    public class ManageProfileWorker
    {
        // Method to update the users personal information in the database
        public static void updatePersonalDetails(int id,string fName, string sName, string studNum, string cell,
            string email, string passwordHash, string passwordSalt)
        {
            Models.STUDYTIMEContext connection = new Models.STUDYTIMEContext();

            Models.Student updateStudent = new Models.Student();

            updateStudent.StudentId = id;
            updateStudent.FirstName = fName;
            updateStudent.Surname = sName;
            updateStudent.StudentNumber = studNum;
            updateStudent.CellNumber = cell;
            updateStudent.EmailAddress = email;
            updateStudent.PasswordSalt = passwordSalt;
            updateStudent.PasswordHash = passwordHash;

            connection.Update(updateStudent);
            connection.SaveChanges();
        }

    }
}
