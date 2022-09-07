using System;
using System.Collections.Generic;
using System.Text;

namespace DoAnTotNghiep.Model
{
    public class DetailModuleClassModel
    {
        public Guid DetailModuleClassID { get; set; }
        public Guid ModuleClassID { get; set; }
        public Guid StudentID { get; set; }
        public float? FrequentPoints1 { get; set; }
        public float? FrequentPoints2 { get; set; }
        public float? MediumScore { get; set; }
        public string ModuleClassCode { get; set; }
        public string StudentCode { get; set; }
        public string FullName { get; set; }
        public string ClassName { get; set; }
        public string CourseName { get; set; }
        public string MajorsName { get; set; }
    }
}
