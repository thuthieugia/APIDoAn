using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoAnTotNghiep.Data
{
    [Table("TechnicalStaff")]
    //Bảng cán bộ kỹ thuật
    public class TechnicalStaffDB  
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid TechnicalStaffID { get; set; }
        public string TechnicalStaffCode { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public virtual ICollection<MaintainanceDB> Maintainances { get; set; }
    }
}
