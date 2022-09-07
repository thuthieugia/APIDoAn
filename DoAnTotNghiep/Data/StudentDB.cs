using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DoAnTotNghiep.Data
{
    [Table("Student")]
    // Bảng sinh viên
    public class StudentDB  
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid StudentID { get; set; }
        public string StudentCode { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int? Gender { get; set; }
        [ForeignKey("Class")]
        public Guid? ClassID { get; set; }
        public string ClassName { get; set; }
        public string ClassCode { get; set; }
        public ClassDB Class { get; set; }

        // public virtual ICollection<Student> Students { get; set; }

        public virtual ICollection<AttendanceDB> Attendances { get; set; }
        public virtual ICollection<DetailModuleClassDB> DetailModuleClasss { get; set; }
        public virtual ICollection<DetailPracticeGroupDB> DetailPracticeGroups { get; set; }
    }
}
