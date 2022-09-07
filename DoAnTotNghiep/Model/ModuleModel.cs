using System;
using System.Collections.Generic;
using System.Text;

namespace DoAnTotNghiep.Model
{
     
    // học phần
    
    public class ModuleModel
    {
        public Guid ModuleID { get; set; }
        public string ModuleCode { get; set; }
        public string ModuleName { get; set; }
        public float? NumberOfModule { get; set; }
        public float? Theory { get; set; }
        public float? Practice { get; set; }
        public float? BigExercise { get; set; }
        public Guid? SubjectID { get; set; }
        public string SubjectName { get; set; }
        public string ModuleClassCode { get; set; }

        //public Guid? TeacherID { get; set; }
        //public string FullName { get; set; }
    }
}
