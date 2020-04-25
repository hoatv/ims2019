using System;
namespace IMS_2019.Models
{
    public class ClauseModel
    {
        public int ClauseID { get; set; }
        public string ClauseOldID { get; set; }
        public int DocumentID { get; set; }
        public string ClauseNo { get; set; }
        public string ClausePage { get; set; }
        public string ClauseContent { get; set; }
        public int DocVersionID { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }

    }
}
