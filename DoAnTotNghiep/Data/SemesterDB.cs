using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DoAnTotNghiep.Data
{
    [Table("Semester")]
    //Thông tin Khoa
    public class SemesterDB  
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid SemesterID { get; set; }
        public string SemesterName { get; set; }
        public virtual ICollection<PracticeScheduleDB> PracticeSchedules { get; set; }
    }
}
