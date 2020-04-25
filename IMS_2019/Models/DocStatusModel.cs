using System;
namespace IMS_2019.Models
{
    public class DocStatusModel
    {
        public int DocStatusID { get; set; }
        public string DocStatusName { get; set; }
        public string DocStatusDescription { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
    }
}
