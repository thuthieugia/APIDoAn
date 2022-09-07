using System;
using System.Collections.Generic;
using System.Text;

namespace DoAnTotNghiep.Model
{
     
    // Giáo viên
    
    public class UserModel
    {
        public Guid UserID { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public Guid? PermissionID { get; set; }
        public string PermissionName { get; set; }
    }
}
