using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoAnTotNghiep.Data
{
    [Table("Maintainance")]
    // Bảng bảo trì
    public class MaintainanceDB  
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid MaintainanceID { get; set; }

        [ForeignKey("PracticalLaboratory")]
        public Guid? PracticalLaboratoryID{ get; set; }

        public string PracticalLaboratoryCode { get; set; }
        public string PracticalLaboratoryName { get; set; }

        public DateTime StartedDate{ get; set; }
        public DateTime EndedDate { get; set; }

        [ForeignKey("TechnicalStaff")]
        public Guid? TechnicalStaffID { get; set; }

        public string TechnicalStaffCode { get; set; }
        public string FullName { get; set; }

        public int MaintainanceStatus { get; set; }

        public int Request { get; set; }
        public string Description { get; set; }

        public PracticalLaboratoryDB PracticalLaboratory { get; set; }
        public TechnicalStaffDB TechnicalStaff { get; set; }
        // public virtual ICollection<Maintainance> Maintainances { get; set; }
    }
}
