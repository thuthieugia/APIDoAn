using System;

namespace DoAnTotNghiep.Model
{
     
    // Bảng lịch thực hành
    
    public class PracticeScheduleModel
    {
        public Guid PracticeScheduleID { get; set; }
        public DateTime Date { get; set; }
        public Guid PracticeShiftID { get; set; }

        public string PracticeShiftName { get; set; }
        public Guid PracticeGroupID { get; set; }

        public string PracticeGroupName { get; set; }
        public Guid PracticalLaboratoryID{ get; set; }
        public string PracticalLaboratoryName{ get; set; }

        public int Status { get; set; }

        public string Description{ get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Guid SchoolYearID { get; set; }
        public string SchoolYearName { get; set; }
        public Guid SemesterID { get; set; }
        public string SemesterName { get; set; }
        public Guid TeacherID { get; set; }
        public string FullName { get; set; }

        public int Request { get; set; }
    }
}
