using IMS_2019.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace IMS_2019.ViewModel
{
    public class ClauseVM
    {
        public ClauseModel clauseModel {get;set;}
        public IEnumerable<DocTypeModel> listDocType { get; set; }
        public IEnumerable<VersionModel> listVersion { get; set; }
        public IEnumerable<DocStatusModel> listDocStatus { get; set; }
        public IEnumerable<DocumentModel> listDocument { get; set; }
        public IPagedList<ClauseModel> listClause { get; set; }

        public IPagedList PagingMetaData { get; set; }

        public String actionType { get; set; }
        
    }
}
