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
    public class CreateAccountWorker
    {
        
        // Method to add the account to the database
        public static void createAccount(string firstName, string surname, string email, string studentNumber, 
            string cell, string pass)
        { 
            Models.STUDYTIMEContext connection = new Models.STUDYTIMEContext();
            Models.Student newStudent = new Models.Student();
            newStudent.FirstName = firstName;
            newStudent.Surname = surname;
            newStudent.EmailAddress = email;
            newStudent.StudentNumber = studentNumber;
            newStudent.CellNumber = cell;
            string salt = PasswordManagement.CreateSalt(20);
            string hash = PasswordManagement.generateHash(pass, salt);
            newStudent.PasswordSalt = salt;
            newStudent.PasswordHash = hash;

            connection.Add(newStudent);
            connection.SaveChanges();

            List<Models.Student> lstStudent = connection.Students.Where(x => x.StudentNumber.Equals(studentNumber)).ToList();
            foreach (Models.Student createAcc in lstStudent)
            {
                if (createAcc.PasswordHash.Equals(hash))
                {
                    ListHandler.currentStudent = connection.Students.Where(x => x.StudentNumber.Equals(studentNumber)).First();
                    break;
                }
            }
        }
    }
}
