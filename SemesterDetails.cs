using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyTimeLibrary
{
    public class SemesterDetails
    {
        private int semesterID;
        private double numberOfWeeks;
        private string startDate;
        private int studentID;

        public SemesterDetails(int semesterID, double numberOfWeeks, string startDate, int studentID)
        {
            this.semesterID = semesterID;
            this.numberOfWeeks = numberOfWeeks;
            this.startDate = startDate;
            this.studentID = studentID;
        }

        public int SemesterID { get => semesterID;}
        public double NumberOfWeeks { get => numberOfWeeks;}
        public string StartDate { get => startDate;}
        public int StudentID { get => studentID;}
    }
}
