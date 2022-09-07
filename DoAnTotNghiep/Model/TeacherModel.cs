using System;

namespace DoAnTotNghiep.Model
{
     
    // Giáo viên
    
    public class TeacherModel
    {
        public Guid TeacherID { get; set; }

        public string TeacherCode { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }

        public string Email { get; set; }
        public Guid? SubjectID { get; set; }
        public string SubjectName { get; set; }
    }
}
