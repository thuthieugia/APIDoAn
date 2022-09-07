using System;
using System.Collections.Generic;
using System.Text;

namespace DoAnTotNghiep.Model
{
     
    // Bảng sinh viên
    
    public class StudentModel
    {

        public Guid StudentID { get; set; }
        public string StudentCode { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int? Gender { get; set; }
        public Guid ClassID { get; set; }
        public string ClassName { get; set; }
        public string ClassCode { get; set; }
    }
}
