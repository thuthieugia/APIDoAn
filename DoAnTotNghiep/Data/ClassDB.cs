using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DoAnTotNghiep.Data
{
    [Table("Class")]
    public class @ClassDB
    {
        // Bảng lớp học
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ClassID { get; set; }
        public string ClassCode { get; set; }
        public string ClassName { get; set; }
        [ForeignKey("Course")]
        public Guid? CourseID { get; set; }
    
        [ForeignKey("Majors")]
        public Guid? MajorsID { get; set; }
    
        public string MajorsName { get; set; }
        public string MajorsCode { get; set; }
        public string CourseName { get; set; }
        public Guid? StudentID { get; set; }
        
        public string FullName { get; set; }

        public CourseDB Course { get; set; }
        public MajorsDB Majors { get; set; }
        public virtual ICollection<StudentDB> Students { get; set; }
    }

}
