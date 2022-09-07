using System;

namespace DoAnTotNghiep.Model
{
     
    // Bảng cán bộ kỹ thuật
    
    public class TechnicalStaffModel
    {
        public Guid TechnicalStaffID { get; set; }
        public string TechnicalStaffCode { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
