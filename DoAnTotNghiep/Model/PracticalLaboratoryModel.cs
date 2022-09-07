using System;
using System.Collections.Generic;
using System.Text;

namespace DoAnTotNghiep.Model
{
     
    // Phòng thực hành
    
    public class PracticalLaboratoryModel 
    {
        public Guid PracticalLaboratoryID { get; set; }
        public string PracticalLaboratoryCode { get; set; }
        public string PracticalLaboratoryName { get; set; }
        public int? NumberOfSeats { get; set; }
        public string Description { get; set; }
        public Guid? BuildingID { get; set; }
        public string BuildingName { get; set; }
        public Guid? OlogyID { get; set; }
        public string OlogyName { get; set; }
        public Guid? SubjectID { get; set; }
        public string SubjectName { get; set; }
        public int Status { get; set; }
    }
}
