using System;

namespace StudyTimeLibrary
{
    public class Student
    {
        private int studentID;
        private string studentNumber;
        private string passwordHash;
        private string firstName;
        private string lastName;
        private string emailAddress;
        private string contactNumber;


        public Student(int studentID, string studentNumber, string passwordHash, string firstName, string lastName, string emailAddress, string contactNumber)
        {
            this.studentID = studentID;
            this.studentNumber = studentNumber;
            this.passwordHash = passwordHash;
            this.firstName = firstName;
            this.lastName = lastName;
            this.emailAddress = emailAddress;
            this.contactNumber = contactNumber;
        }

        public int StudentID { get => studentID; }
        public string StudentNumber { get => studentNumber;}
        public string PasswordHash { get => passwordHash;}
        public string FirstName { get => firstName;}
        public string LastName { get => lastName;}
        public string EmailAddress { get => emailAddress;}
        public string ContactNumber { get => contactNumber;}
    }
}
