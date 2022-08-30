using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyTimeLibrary
{
    public class StudyRecord
    {
        private int studentID;
        private int moduleID;
        private string dateStudied;
        private double hoursStudied;

        public StudyRecord(int studentID, int moduleID, 
            string dateStudied, double hoursStudied)
        {
            this.studentID = studentID;
            this.moduleID = moduleID;
            this.dateStudied = dateStudied;
            this.hoursStudied = hoursStudied;
        }

        public int StudentID { get => studentID;}
        public int ModuleID { get => moduleID;}
        public string DateStudied { get => dateStudied;}
        public double HoursStudied { get => hoursStudied;}}
}
