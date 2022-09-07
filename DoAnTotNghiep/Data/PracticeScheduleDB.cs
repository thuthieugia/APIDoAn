using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoAnTotNghiep.Data
{
    [Table("PracticeSchedule")]

    // Bảng lịch thực hành
    public class PracticeScheduleDB  
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid PracticeScheduleID { get; set; }
        public DateTime Date { get; set; }

        [ForeignKey("PracticeShift")]
        public Guid? PracticeShiftID { get; set; }

        public string PracticeShiftName { get; set; }

        [ForeignKey("PracticeGroup")]
        public Guid? PracticeGroupID { get; set; }

        public string PracticeGroupName { get; set; }

        [ForeignKey("PracticalLaboratory")]
        public Guid? PracticalLaboratoryID{ get; set; }
        public string PracticalLaboratoryName{ get; set; }

        public int Status { get; set; }

        public string Description{ get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        [ForeignKey("SchoolYear")]
        public Guid? SchoolYearID { get; set; }

        public string SchoolYearName { get; set; }
        [ForeignKey("Semester")]
        public Guid? SemesterID { get; set; }

        public string SemesterName { get; set; }
        [ForeignKey("Teacher")]
        public Guid? TeacherID { get; set; }

        public string FullName { get; set; }

        public int Request { get; set; }

        
        public PracticeShiftDB PracticeShift { get; set; }
        public PracticeGroupDB PracticeGroup { get; set; }
        public PracticalLaboratoryDB PracticalLaboratory { get; set; }
        public SchoolYearDB SchoolYear { get; set; }
        public SemesterDB Semester { get; set; }
        public TeacherDB Teacher { get; set; }

        // public virtual ICollection<PracticeSchedule> PracticeSchedules { get; set; }
        public virtual ICollection<AttendanceDB> Attendances { get; set; }
    }
}
