using System;
namespace IMS_2019.Models
{
    public class ReplyModel
    {
        public int ReplyID { get; set; }
        public string ReplyIDOld { get; set; }
        public string IssueIDOld { get; set; }
        public int IssueID { get; set; }
        public int ClauseIssueID { get; set; }
        public string ReplyContent { get; set; }
        public string EmailSender { get; set; }

        public int CreatedBy { get; set; }
        public string CreatedName { get; set; }
        public int UpdatedBy { get; set; }
        public string UpdatedName { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
    }
}
