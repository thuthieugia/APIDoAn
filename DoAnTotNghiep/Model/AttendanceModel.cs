using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DoAnTotNghiep.Model
{
    public class AttendanceModel
    {
        public Guid AttendanceID { get; set; }
        public Guid StudentID { get; set; }
        public string StudentCode { get; set; }
        public string FullName { get; set; }        
        public Guid PracticeScheduleID { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Description { get; set; }
        public int AttendanceStatus { get; set; }
        public string AttendanceStudentName { get; set; }
        public string AttendanceStudentCode { get; set; }
        public string AttendancePracticeSchedule { get; set; }
    }
}
