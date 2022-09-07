using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DoAnTotNghiep.Data
{
    [Table("DetailPracticeGroup")]
    public class DetailPracticeGroupDB  
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid DetailPracticeGroupID { get; set; }
        [ForeignKey("PracticeGroup")]
        public Guid? PracticeGroupID { get; set; }

        [ForeignKey("Student")]
        public Guid? StudentID { get; set; }

        public string Note { get; set; }
        public string PracticeGroupCode { get; set; }
        public string PracticeGroupName { get; set; }
        public string StudentCode { get; set; }
        public string FullName { get; set; }
        public string ClassName { get; set; }
        public PracticeGroupDB PracticeGroup { get; set; }
        public StudentDB Student { get; set; }
        // public virtual ICollection<DetailPracticeGroup> DetailPracticeGroups { get; set; }
    }
}
