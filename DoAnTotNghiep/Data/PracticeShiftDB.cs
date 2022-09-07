using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DoAnTotNghiep.Data
{
    [Table("PracticeShift")]
    public class PracticeShiftDB  
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid PracticeShiftID { get; set; }
        public string PracticeShiftName { get; set; }
        public Nullable<DateTime> StartTime { get; set; }
        public Nullable<DateTime> EndTime { get; set; }
        public virtual ICollection<PracticeScheduleDB> PracticeSchedules { get; set; }
    }
}
