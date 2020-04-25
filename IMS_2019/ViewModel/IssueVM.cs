using System;
using System.Collections.Generic;
using IMS_2019.Models;
using X.PagedList;

namespace IMS_2019.ViewModel
{
    public class IssueVM
    {
        public IssueModel issModel;
        public IPagedList<IssueModel> listIssue { get; set; }
        public string IssueStatusName { get; set; }
        public string CreatorName { get; set; }
        public string UpdatedName { get; set; }
        public IEnumerable<DocTypeModel> listDocType { get; set; }
        public IEnumerable<VersionModel> listVersion { get; set; }
        public IEnumerable<DocStatusModel> listDocStatus { get; set; }
        public IEnumerable<ClauseIssueModel> listClauseIssue { get; set; }
        public List<IssStatusModel> listIssStatus { get; set; }
        public IEnumerable<ClauseModel> listClause { get; set; }
        public IPagedList PagingMetaData { get; set; }
        public string actionType {get;set;}

    }
}
