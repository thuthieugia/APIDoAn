using System;
using System.Collections.Generic;
using System.Text;

namespace DoAnTotNghiep.Model
{
    public class DetailPracticeGroupModel 
    {
        public Guid DetailPracticeGroupID { get; set; }
        public Guid PracticeGroupID { get; set; }
        public Guid StudentID { get; set; }
        public string Note { get; set; }
        public string PracticeGroupCode { get; set; }
        public string PracticeGroupName { get; set; }
        public string StudentCode { get; set; }
        public string FullName { get; set; }
        public string ClassName { get; set; }
    }
}
