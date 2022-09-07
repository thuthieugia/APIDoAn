using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DoAnTotNghiep.Data
{
    [Table("ModuleClass")]
    // Lớp học phần
    public class ModuleClassDB  
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ModuleClassID { get; set; }
        public string ModuleClassCode { get; set; }
        [ForeignKey("Module")]
        public Guid? ModuleID { get; set; }

        [ForeignKey("Semester")]
        public Guid? SemesterID { get; set; }

        public string SemesterName { get; set; }
        public int? Status { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string ModuleName { get; set; }
        public string ModuleCode { get; set; }
        public string SubjectName { get; set; }
        public string FullName { get; set; }
        public int NumberOfModule { get; set; }
        [ForeignKey("Teacher")]
        public Guid? TeacherID { get; set; }

        [ForeignKey("SchoolYear")]
        public Guid SchoolYearID { get; set; }

        public string SchoolYearName { get; set; }

        public TeacherDB Teacher { get; set; }
        public SchoolYearDB SchoolYear { get; set; }
        // public virtual ICollection<ModuleClass> ModuleClasss { get; set; }
        public virtual ICollection<DetailModuleClassDB> DetailModuleClasss { get; set; }
        public virtual ICollection<PracticeGroupDB> PracticeGroups { get; set; }
    }
}
