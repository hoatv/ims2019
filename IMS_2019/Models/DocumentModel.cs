using System;
namespace IMS_2019.Models
{
    public class DocumentModel
    {
        public int DocumentID { get; set; }
        public string DocumentOldID { get; set; }
        public int DocumentTypeID { get; set; }
        public string DocumentName { get; set; }
        public int VersionID { get; set; }
        public string URL { get; set; }
        public string Description { get; set; }
        public int DocStatusID { get; set; }
        public string CreatorID { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }

        public string DocTypeName { get; set; }
        public string VersionName { get; set; }
        public string DocStatusName { get; set; }
        public string CreatorName { get; set; }
        public string UpdatedName { get; set; }


    }
}
