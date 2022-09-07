using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DoAnTotNghiep.Data
{
    [Table("PracticeGroup")]
    /// <summary>
    /// Nhóm
    /// </summary>
    public class PracticeGroupDB  
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid PracticeGroupID { get; set; }
        public string PracticeGroupCode { get; set; }
        [ForeignKey("ModuleClass")]
        public Guid? ModuleClassID { get; set; }
        public string PracticeGroupName { get; set; }
        [ForeignKey("Teacher")]
        public Guid? TeacherID { get; set; }

        public string FullName { get; set; }
        public string Note { get; set; }
 
        public string ModuleClassCode { get; set; }
        public string ModuleName { get; set; }
        public string SubjectName { get; set; }
        public ModuleClassDB ModuleClass { get; set; }
        public TeacherDB Teacher { get; set; }
        // public virtual ICollection<PracticeGroup> PracticeGroups { get; set; }
        public virtual ICollection<DetailPracticeGroupDB> DetailPracticeGroups { get; set; }
        public virtual ICollection<PracticeScheduleDB> PracticeSchedules { get; set; }
    }
}
