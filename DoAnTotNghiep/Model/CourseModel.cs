using System;
using System.Collections.Generic;
using System.Text;

namespace DoAnTotNghiep.Model
{
    // Khóa học
    
    public class CourseModel
    {
        public Guid CourseID { get; set; }
        public string CourseName { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
    }
}
