using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DoAnTotNghiep.Data
{
    [Table("SchoolYear")]
    // Thông tin Khoa
    public class SchoolYearDB  
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid SchoolYearID { get; set; }
        public string SchoolYearName { get; set; }
        public virtual ICollection<ModuleClassDB> ModuleClasss { get; set; }
        public virtual ICollection<PracticeScheduleDB> PracticeSchedules { get; set; }
    }
}
