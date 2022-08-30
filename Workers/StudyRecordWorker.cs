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
    public class StudyRecordWorker
    {
        // Method to retrieve the users study record from the database and store it in the List Handler class
        public static void retrieveStudyRecord()
        {
            Models.STUDYTIMEContext connection = new Models.STUDYTIMEContext();

            List<Models.StudyRecord> lstAllRecords = connection.StudyRecords.ToList(); ;

            ListHandler.lstStudyRecord.Clear();

            foreach (Models.Module findMod in ListHandler.lstModule)
            {
                foreach (Models.StudyRecord findRec in lstAllRecords)
                {
                    if (findMod.ModuleId.Equals(findRec.ModuleId))
                    {
                        ListHandler.lstStudyRecord.Add(findRec);
                    }

                }
            }
        }

        // Method to create a new study record record in the database
        public static void createStudyRecord(int modID, string dateStudied, string hoursStudied)
        {
            Models.STUDYTIMEContext connection = new Models.STUDYTIMEContext();
            Models.StudyRecord record = new Models.StudyRecord();

            record.ModuleId = modID;
            record.DateStudied = Convert.ToDateTime(dateStudied);
            record.HoursStudied = Convert.ToDecimal(hoursStudied);

            connection.Add(record);
            connection.SaveChanges();
            retrieveStudyRecord();
        }

        // Method to get the modules ID for the module selected by the user
        public static int getModuleID(string selected)
        {
            string[] arrSelectedModule = selected.Split("-");
            string code = arrSelectedModule[0];
            string name = arrSelectedModule[1];
            int modID = 0;
            foreach (Models.Module display in ListHandler.lstModule)
            {
                if (display.ModuleCode.Equals(code) && display.ModuleName.Equals(name))
                {
                    modID = display.ModuleId;
                }
            }
            return modID;
        }

        // Method to filter the study record based on a week in the semester
        public static string filterStudyRecord(int weekChosen)
        {
            retrieveStudyRecord();
            DateTime weekStart;
            DateTime weekEnd;
            if (weekChosen <= 1)
            {
                weekChosen = 1;
                weekStart = StudyTimeLibrary.ListHandler.currentSemester.StartDate;
                weekEnd = weekStart.AddDays(7);
            }
            else
            {
                weekStart = StudyTimeLibrary.ListHandler.currentSemester.StartDate.AddDays(weekChosen * 7);
                weekEnd = weekStart.AddDays(7);
            }
            string filtered = "";
            foreach (Models.StudyRecord filter in ListHandler.lstStudyRecord)
            {
                foreach (Models.Module get in ListHandler.lstModule)
                {
                    if (filter.DateStudied <= weekEnd && filter.DateStudied >= weekStart && filter.ModuleId.Equals(get.ModuleId))
                    {
                        filtered += "MODEL CODE: " + get.ModuleCode + "\rMODULE NAME: " + get.ModuleName +
                            "\rDATE STUDIED: " + filter.DateStudied.ToString().Substring(0,10) + "\rHOURS STUDIED: " + filter.HoursStudied + "\n";
                    }
                }
            }
            return filtered;
        }

        // Method to print the users 
        public static string printStudyRecord()
        {
            retrieveStudyRecord();
            string filtered = "";
            foreach (Models.StudyRecord filter in ListHandler.lstStudyRecord)
            {
                foreach (Models.Module get in ListHandler.lstModule)
                {
                    if (filter.ModuleId.Equals(get.ModuleId))
                    {
                        filtered += "MODEL CODE: " + get.ModuleCode + "\rMODULE NAME: " + get.ModuleName +
                            "\rDATE STUDIED: " + filter.DateStudied + "\rHOURS STUDIED: " + filter.HoursStudied + "\n";
                    }
                }
            }
            return filtered;
        }
    }
}
