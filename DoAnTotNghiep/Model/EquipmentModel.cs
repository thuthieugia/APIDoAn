using System;

namespace DoAnTotNghiep.Model
{
     
    // Trang thiết bị
    
    public class EquipmentModel
    {
        public Guid EquipmentID { get; set; }

        public string EquipmentCode { get; set; }

        public Guid PracticalLaboratoryID { get; set; }

        public string EquipmentName { get; set; }
        public string Description { get; set; }
        public int EquipmentStatus { get; set; }
    }
}
