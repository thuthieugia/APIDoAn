using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DoAnTotNghiep.Data
{
    [Table("Users")]
    // Giáo viên
    public class UserDB
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid UserID { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        [ForeignKey("Permission")]
        public Guid? PermissionID { get; set; }

        public string PermissionName { get; set; }
        
        public PermissionDB Permission { get; set; }
    }
}
