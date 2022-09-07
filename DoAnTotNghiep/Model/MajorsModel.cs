using System;
using System.Collections.Generic;
using System.Text;

namespace DoAnTotNghiep.Model
{
     
    // Thông tin ngành
    
    public class MajorsModel
    {
        public Guid MajorsID { get; set; }
        public string MajorsCode { get; set; }
        public string MajorsName { get; set; }
        public Guid? OlogyID { get; set; }
        public string MajorsOlogy { get; set; }
    }
}
