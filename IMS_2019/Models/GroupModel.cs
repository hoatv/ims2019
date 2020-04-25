using System;
namespace IMS_2019.Models
{
    public class GroupModel
    {
        public int GroupID { get; set; }
        public string UserGroupID { get; set; }
        public string GroupName { get; set; }
        public string GroupDescription { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
    }
}
