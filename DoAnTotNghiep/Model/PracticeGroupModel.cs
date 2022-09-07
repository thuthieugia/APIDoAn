using System;
using System.Collections.Generic;
using System.Text;

namespace DoAnTotNghiep.Model
{
     
    // Nhóm
    
     public class PracticeGroupModel
    {

        public Guid PracticeGroupID { get; set; }
        public string PracticeGroupCode { get; set; }
        public Guid? ModuleClassID { get; set; }
        public string PracticeGroupName { get; set; }
        public Guid TeacherID { get; set; }
        public string FullName { get; set; }
        public string Note { get; set; }
 
        public string ModuleClassCode { get; set; }
        public string ModuleName { get; set; }
        public string SubjectName { get; set; }

    }
}
