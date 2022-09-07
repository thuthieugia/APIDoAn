using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DoAnTotNghiep.Data 
{
    // Tòa nhà
    [Table("Building")]
    public class BuildingDB
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid BuildingID { get; set; }
        public string BuildingName { get; set; }
        
        public string BaseBuilding { get; set; }

        public virtual ICollection<PracticalLaboratoryDB> PracticalLaboratorys { get; set; }
    }
}
