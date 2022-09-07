using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DoAnTotNghiep.Data
{
    // Thông tin Khoa
    [Table("Permission")]
    public class PermissionDB  
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid PermissionID { get; set; }
        public string PermissionName { get; set; }

        public virtual ICollection<UserDB> Users { get; set; }
    }
}
