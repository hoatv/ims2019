using System;
namespace IMS_2019.Models
{
    public class IssStatusModel
    {
        public int IssStatusID { get; set; }
        public string IssStatusName { get; set; }
        public string IssStatusDescription { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
    }
}
