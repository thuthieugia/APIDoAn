using System;

namespace DoAnTotNghiep.Model
{
     
    // Bảng bảo trì
    
    public class MaintainanceModel
    {

        public Guid MaintainanceID { get; set; }
        public Guid PracticalLaboratoryID{ get; set; }

        public string PracticalLaboratoryCode { get; set; }
        public string PracticalLaboratoryName { get; set; }

        public DateTime StartedDate{ get; set; }
        public DateTime EndedDate { get; set; }

        public Guid TechnicalStaffID { get; set; }
        public string TechnicalStaffCode { get; set; }
        public string FullName { get; set; }

        public int MaintainanceStatus { get; set; }

        public int Request { get; set; }
        public string Description { get; set; }
    }
}
