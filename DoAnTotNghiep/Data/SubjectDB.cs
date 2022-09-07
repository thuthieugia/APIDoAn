using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DoAnTotNghiep.Data
{
    [Table("Subject")]

    // Bảng bộ môn
    public class SubjectDB  
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid SubjectID { get; set; }
        public string SubjectName { get; set; }

        public virtual ICollection<ModuleDB> Modules { get; set; }
        public virtual ICollection<PracticalLaboratoryDB> PracticalLaboratorys { get; set; }
        public virtual ICollection<TeacherDB> Teachers { get; set; }
    }
}
