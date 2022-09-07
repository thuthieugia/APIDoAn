using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DoAnTotNghiep.Data
{
    [Table("Ology")]
    // Thông tin Khoa
    public class OlogyDB  
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid OlogyID { get; set; }
        public string OlogyName { get; set; }
        public virtual ICollection<MajorsDB> Majors { get; set; }
        public virtual ICollection<PracticalLaboratoryDB> PracticalLaboratorys { get; set; }
    }
}
