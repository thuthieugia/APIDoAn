using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DoAnTotNghiep.Data
{
    [Table("Majors")]
    // Thông tin ngành
    public class MajorsDB  
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid MajorsID { get; set; }

        public string MajorsCode { get; set; }
        public string MajorsName { get; set; }
        [ForeignKey("Ology")]
        public Guid? OlogyID { get; set; }

        public string OlogyName { get; set; }


        public OlogyDB Ology { get; set; }
        // public virtual ICollection<Majors> Majors { get; set; }
        public virtual ICollection<ClassDB> Classs { get; set; }
    }
}
