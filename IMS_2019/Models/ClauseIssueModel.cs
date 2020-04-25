using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMS_2019.Models
{
    public class ClauseIssueModel
    {
        public int ClauseIssueID { get; set; }
        public string ClauseIssueIDOld { get; set; }
        public int ClauseID { get; set; }
        public int IssueID { get; set; }
        public string UrlScreenshot { get; set; }
        public string EmailText { get; set; }
        public string URLAttachment { get; set; }
        public string EmailSender { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedName { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedName { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
    }
}
