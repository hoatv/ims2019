using System;
namespace IMS_2019.Models
{
    public class IssueModel
    {
        //public int IssueID { get; set; }
        //public int IssueStatusID { get; set; }
        //public string IssueContent { get; set; }
        //public string EmailSender { get; set; }
        //public string EmailProcessorer { get; set; }
        //public string NextStep { get; set; }
        //public int CreatedBy { get; set; }
        //public int UpdatedBy { get; set; }
        //public string CreatedAt { get; set; }
        //public string UpdatedAt { get; set; }

        public int IssueID { get; set; }
        public string IssueIDOld { get; set; }
        public int ClauseIssueID { get; set; }
        public int ClauseID { get; set; }
        public string IssueContent { get; set; }
        public string ClauseNo { get; set; }
        public string Clausepage { get; set; }
        public string EmailSender { get; set; }
        public int IssueStatus_ID { get; set; }
        public string EmailProcessorer { get; set; }
        public string NextStep { get; set; }

        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
        public string CreatedName { get; set; }
        public string UpdatedName { get; set; }
    }
}
