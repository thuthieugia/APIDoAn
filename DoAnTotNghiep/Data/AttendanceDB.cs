using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DoAnTotNghiep.Data
{

    [Table("Attendance")]
    public class AttendanceDB
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid AttendanceID { get; set; }
        [ForeignKey("Student")]
        public Guid? StudentID { get; set; }

        public string StudentCode { get; set; }
        public string FullName { get; set; }
        [ForeignKey("PracticeSchedule")]
        public Guid? PracticeScheduleID { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Description { get; set; }
        public int AttendanceStatus { get; set; }

        public StudentDB Student { get; set; }
        public PracticeScheduleDB PracticeSchedule { get; set; }



    }
}
