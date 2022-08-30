// Keshan Padayachee
// 20121106
// PROG 6212
// Portfolio Of Evidence
// Task 2
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StudyTimeLibrary
{
    public class ModuleWorker
    {
        // Method to add the students module to the database
        public static void addModule(string moduleCode, string moduleName, int moduleCredits, decimal classHours)
        {
            Models.STUDYTIMEContext connection = new Models.STUDYTIMEContext();
            Models.Module newModule = new Models.Module();
            newModule.ModuleCode = moduleCode;
            newModule.ModuleName = moduleName;
            newModule.NumberCredits = moduleCredits;
            newModule.ClassHours = Convert.ToDecimal(classHours);
            newModule.StudentId = ListHandler.currentStudent.StudentId;

            connection.Add(newModule);
            connection.SaveChanges();
        }

        // Method to filter the students modules from the database
        public static void filterStudentModules()
        {
            Thread.Sleep(1000);
            Models.STUDYTIMEContext connection = new Models.STUDYTIMEContext();
            if (connection.Modules.Where(x => x.StudentId.Equals(ListHandler.currentStudent.StudentId)).Any())
            {
                ListHandler.lstModule = connection.Modules.Where(x => x.StudentId.Equals(ListHandler.currentStudent.StudentId)).ToList();
            }
        }

        // Method to calculate the current week of the semester
        public static int calculateWeek()
        {
            // Code Attribution: Counting number of weeks between two dates
            // Stack Overflow
            // Most efficient way to count number of weeks between two datetimes [closed]
            // Date Publishes: 05 May 2011
            // Date Accessed: 20 October 2021
            // https://stackoverflow.com/questions/5893255/most-efficient-way-to-count-number-of-weeks-between-two-datetimes
           

            if (ListHandler.currentStudent != null)
            {
                int weekNumber = Convert.ToInt32(Math.Floor((DateTime.Now - StudyTimeLibrary.ListHandler.currentSemester.StartDate).TotalDays / 7));
                if (ListHandler.lstModule.Where(x => x.StudentId.Equals(ListHandler.currentStudent.StudentId)).Any())
                {
                    if (weekNumber <= 1)
                    {
                        weekNumber = 1 + Convert.ToInt32(Math.Floor((DateTime.Now - StudyTimeLibrary.ListHandler.currentSemester.StartDate).TotalDays / 7));
                    }
                    else
                    {
                        weekNumber = Convert.ToInt32(Math.Floor((DateTime.Now - StudyTimeLibrary.ListHandler.currentSemester.StartDate).TotalDays / 7));
                    }
                    return weekNumber;
                }
               
            }

             return 0;
           
            
        }

        // Method to show the details of the selected module
        public static string showSelectedModule(string selected)
        {
            string[] arrSelectedModule = selected.Split("-");
            string code = arrSelectedModule[0];
            string name = arrSelectedModule[1];
            foreach (Models.Module display in ListHandler.lstModule)
            {
                if (display.ModuleCode.Equals(code) && display.ModuleName.Equals(name))
                {
                    double selfStudy = CalculateSelfStudyHours.selfStudyHoursCalculator(display.NumberCredits,
                        ListHandler.currentSemester.NumWeeks, Convert.ToDouble(display.ClassHours));
                    return "MODULE CODE: " + display.ModuleCode + "\rMODULE NAME: " + display.ModuleName
                        + "\rMODULE CREDITS: " + display.NumberCredits + "\rCLASS HOURS/WEEK: " + display.ClassHours
                        + "\rSELF STUDY HOURS: " + selfStudy
                        + "\n\nHOURS STUDIED THIS WEEK: " + calculateHoursStudiedThisWeek(display.ModuleId)
                        + "\rHOURS REM. THIS WEEK: " + calculateHoursRemainingWeek(selfStudy, display.ModuleId)
                        + "\nHOURS REMAINING THIS SEMESTER: " + calculateHoursRemainingSemester(selfStudy, display.ModuleId);
                }
            }
            return "No Details Found!";
        }

        // Method to calculate the hours the user studied in the current week of the semester
        public static double calculateHoursStudiedThisWeek(int modID)
        {
            StudyRecordWorker.retrieveStudyRecord();
            int week = Convert.ToInt32(calculateWeek());
            DateTime weekStart;
            DateTime weekEnd;
            if (week <= 1)
            {
                week = 1;
                weekStart = StudyTimeLibrary.ListHandler.currentSemester.StartDate;
                weekEnd = weekStart.AddDays(7);
            }
            else
            {
                weekStart = StudyTimeLibrary.ListHandler.currentSemester.StartDate.AddDays(week * 7);
                weekEnd = weekStart.AddDays(7);
            }


            double hoursStudied = 0;

            foreach (Models.StudyRecord addHours in ListHandler.lstStudyRecord)
            {
                if (addHours.ModuleId.Equals(modID) && (addHours.DateStudied >= weekStart && addHours.DateStudied <= weekEnd))
                {
                    hoursStudied += Convert.ToDouble(addHours.HoursStudied);
                }

            }
            return hoursStudied;
        }

        // Method to calculate the hours studied for the previous week
        public static double calculateHoursStudiedPreviousWeek(int modID)
        {
            StudyRecordWorker.retrieveStudyRecord();
            int week = Convert.ToInt32(calculateWeek());
            DateTime weekStart = ListHandler.currentSemester.StartDate.AddDays(week * 7);
            DateTime weekEnd = weekStart.AddDays(7);
            double hoursStudied = 0;
            
                foreach (Models.StudyRecord addHours in ListHandler.lstStudyRecord)
                {
                    if (addHours.ModuleId == modID /*&& addHours.DateStudied >= weekStart && addHours.DateStudied <= weekEnd*/)
                    {
                        return hoursStudied += Convert.ToDouble(addHours.HoursStudied);
                    }

                }

            
            return hoursStudied;
        }

        // Method to calculate the hours remaining for the current week
        public static double calculateHoursRemainingWeek(double self, int modID)
        {
            double remain = (self - calculateHoursStudiedThisWeek(modID)) + calculateHoursStudiedPreviousWeek(modID);
            return remain;
        }

        // Method to calculate the hours studied over the semester for a module
        public static double calculateHoursStudiedSemester(int modID)
        {
            StudyRecordWorker.retrieveStudyRecord();

            double hoursStudied = 0;
            foreach (Models.StudyRecord addHours in ListHandler.lstStudyRecord)
            {
                if (addHours.ModuleId == modID)
                {
                    hoursStudied += Convert.ToDouble(addHours.HoursStudied);
                }

            }
            return hoursStudied;
        }

        // Method to calculate the hours remaining for the semester
        public static double calculateHoursRemainingSemester(double self, int modID)
        {
            double remain = (self * ListHandler.currentSemester.NumWeeks) - calculateHoursStudiedSemester(modID);
            return remain;
        }

    }
}
