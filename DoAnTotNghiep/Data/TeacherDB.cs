using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoAnTotNghiep.Data
{
    [Table("Teacher")]
    // Giáo viên
    public class TeacherDB  
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid TeacherID { get; set; }
        public string TeacherCode { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        [ForeignKey("Subject")]
        public Guid? SubjectID { get; set; }

        public string SubjectName { get; set; }
        public SubjectDB Subject { get; set; }

        // public virtual ICollection<Teacher> Teachers { get; set; }
        public virtual ICollection<ModuleClassDB> ModuleClasss { get; set; }
        public virtual ICollection<PracticeGroupDB> PracticeGroups { get; set; }
        public virtual ICollection<PracticeScheduleDB> PracticeSchedules { get; set; }
    }
}
