using System;
using System.Collections.Generic;
using System.Text;

namespace DoAnTotNghiep.Model
{
    public class PracticeShiftModel
    {
        public Guid PracticeShiftID { get; set; }

        public string PracticeShiftName { get; set; }
        public Nullable<DateTime> StartTime { get; set; }
        public Nullable<DateTime> EndTime { get; set; }
        
    }
}
