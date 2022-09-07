using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DoAnTotNghiep.Data
{
    [Table("DetailModuleClass")]
    public class DetailModuleClassDB  
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid DetailModuleClassID { get; set; }
        [ForeignKey("ModuleClass")]
        public Guid? ModuleClassID { get; set; }

        [ForeignKey("Student")]
        public Guid? StudentID { get; set; }

        public float? FrequentPoints1 { get; set; }
        public float? FrequentPoints2 { get; set; }
        public float? MediumScore { get; set; }
        public string ModuleClassCode { get; set; }
        public string StudentCode { get; set; }
        public string FullName { get; set; }
        public string ClassName { get; set; }
        public string CourseName { get; set; }
        public string MajorsName { get; set; }

        public ModuleClassDB ModuleClass { get; set; }
        public StudentDB Student { get; set; }
        // public virtual ICollection<DetailModuleClass> DetailModuleClasss { get; set; }
    }
}
