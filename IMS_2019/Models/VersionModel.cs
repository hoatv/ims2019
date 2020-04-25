using System;
namespace IMS_2019.Models
{
    public class VersionModel
    {
        public int VersionID { get; set; }
        public string VersionName { get; set; }
        public string VersionDescription { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
    }
}
