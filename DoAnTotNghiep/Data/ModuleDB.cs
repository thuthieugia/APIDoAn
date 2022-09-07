using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DoAnTotNghiep.Data
{
    [Table("Module")]
    // học phần
    public class ModuleDB  
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ModuleID { get; set; }
        public string ModuleCode { get; set; }
        public string ModuleName { get; set; }
        public float? NumberOfModule { get; set; }
        public float? Theory { get; set; }
        public float? Practice { get; set; }
        public float? BigExercise { get; set; }
        [ForeignKey("Subject")]
        public Guid? SubjectID { get; set; }

        public string SubjectName { get; set; }
        public string ModuleClassCode { get; set; }

        //public Guid? TeacherID { get; set; }
        //public string FullName { get; set; }
        public SubjectDB Subject { get; set; }
        // public virtual ICollection<Module> Modules { get; set; }
    }
}
