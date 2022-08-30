using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyTimeLibrary
{
    public class Module
    {
        private int moduleID;
        private string moduleCode;
        private string moduleName;
        private int moduleCredits;
        private double classHoursPerWeek;
        private int studentID;

        public Module(int moduleID, string moduleCode, string moduleName, int moduleCredits, 
            double classHoursPerWeek, int studentID)
        {
            this.moduleID = moduleID;
            this.moduleCode = moduleCode;
            this.moduleName = moduleName;
            this.moduleCredits = moduleCredits;
            this.classHoursPerWeek = classHoursPerWeek;
            this.studentID = studentID;
        }

        public int ModuleID { get => moduleID;}
        public string ModuleCode { get => moduleCode;}
        public string ModuleName { get => moduleName;}
        public int ModuleCredits { get => moduleCredits;}
        public double ClassHoursPerWeek { get => classHoursPerWeek;}
        public int StudentID { get => studentID;}
    }
}
