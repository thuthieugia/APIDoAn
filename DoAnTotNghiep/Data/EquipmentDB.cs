using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoAnTotNghiep.Data
{
    [Table("Equipment")]
    // Trang thiết bị
    public class EquipmentDB  
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid EquipmentID { get; set; }
        public string EquipmentCode { get; set; }

        [ForeignKey("PracticalLaboratory")]
        public Guid? PracticalLaboratoryID { get; set; }
        public string EquipmentName { get; set; }
        public string Description { get; set; }
        public int EquipmentStatus { get; set; }

        public PracticalLaboratoryDB PracticalLaboratory { get; set; }
        // public virtual ICollection<Equipment> Equipments { get; set; }

    }
}
