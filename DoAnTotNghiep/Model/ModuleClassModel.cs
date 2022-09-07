using System;
using System.Collections.Generic;
using System.Text;

namespace DoAnTotNghiep.Model
{
     
    // Lớp học phần
    
    public class ModuleClassModel 
    {
        public Guid ModuleClassID { get; set; }

        public string ModuleClassCode { get; set; }
        public Guid? ModuleID { get; set; }
        public Guid SemesterID { get; set; }
        public string SemesterName { get; set; }
        public int? Status { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }
        public string ModuleName { get; set; }
        public string ModuleCode { get; set; }
        public string SubjectName { get; set; }
        public string FullName { get; set; }
        public int NumberOfModule { get; set; }
        public Guid TeacherID { get; set; }
        public Guid SchoolYearID { get; set; }
        public string SchoolYearName { get; set; }
    }
}
