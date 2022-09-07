using System;
using System.Collections.Generic;
using System.Text;

namespace DoAnTotNghiep.Model
{
    public class @ClassModel
    {
         
        // Bảng lớp học

        public Guid ClassID { get; set; }

        public string ClassCode { get; set; }
        public string ClassName { get; set; }

        public Guid? CourseID { get; set; }
        public Guid? MajorsID { get; set; }
        public string ClassMajors { get; set; }
        public string ClassCourse { get; set; }

    }

}
