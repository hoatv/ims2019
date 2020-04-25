using IMS_2019.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace IMS_2019.ViewModel
{
    public class DocumentVM
    {
        public IEnumerable<DocTypeModel> listDocType { get; set; }
        public IEnumerable<VersionModel> listVersion { get; set; }
        public IEnumerable<DocStatusModel> listDocStatus { get; set; }
        public  IPagedList<DocumentModel> listDocument { get; set; }
        public  List<DocumentModel> listDocuments { get; set; }
        //public PagedList<DocumentModel>
        //public PagedList.IPagedList<DocumentModel> listDocument { get; set; }
        public DocumentModel documentModel { get; set; }

        public int PageCount { get; set; }
        public int PageNumber { get; set; }
        public int Page { get; set; }

        public IPagedList PagingMetaData { get; set; }
    }
}
