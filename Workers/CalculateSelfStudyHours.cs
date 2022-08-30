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
    public class CalculateSelfStudyHours
    {
        // Method to calculate the number of self study hours the student will have to complete
        public static double selfStudyHoursCalculator(int numberOfCredits, double numberOfWeeks,
            double hoursPerWeek)
        {
            double selfStudyHours;
            selfStudyHours = ((numberOfCredits * 10) / numberOfWeeks) - hoursPerWeek;
            return selfStudyHours;
        }
    }
}
