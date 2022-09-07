using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DoAnTotNghiep.Data
{
    [Table("PracticalLaboratory")]

    // Phòng thực hành

    public class PracticalLaboratoryDB  
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid PracticalLaboratoryID { get; set; }
        public string PracticalLaboratoryCode { get; set; }
        public string PracticalLaboratoryName { get; set; }
        public int? NumberOfSeats { get; set; }
        public string Description { get; set; }
        [ForeignKey("Building")]
        public Guid? BuildingID { get; set; }
        public string BuildingName { get; set; }

        [ForeignKey("Ology")]
        public Guid? OlogyID { get; set; }
        public string OlogyName { get; set; }

        [ForeignKey("Subject")]
        public Guid? SubjectID { get; set; }
        public string SubjectName { get; set; }
        public int Status { get; set; }


        public BuildingDB Building { get; set; }
        public OlogyDB Ology { get; set; }
        public SubjectDB Subject { get; set; }
        // public virtual ICollection<PracticalLaboratory> PracticalLaboratorys { get; set; }

        public virtual ICollection<EquipmentDB> Equipments { get; set; }
        public virtual ICollection<MaintainanceDB> Maintainances { get; set; }
        public virtual ICollection<PracticeScheduleDB> PracticeSchedules { get; set; }
    }
}
