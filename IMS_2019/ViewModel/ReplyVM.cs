using IMS_2019.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace IMS_2019.ViewModel
{
    public class ReplyVM
    {
        public ReplyModel replyModel { get; set; }
        public ClauseModel clauseModel { get; set; }
        public IEnumerable<ClauseIssueModel> listClauseIssueModels { get; set; }
        public IEnumerable<IssueModel> listIssue { get; set; }
        public IEnumerable<DocTypeModel> listDocType { get; set; }
        public IEnumerable<VersionModel> listVersion { get; set; }
        public IEnumerable<DocStatusModel> listDocStatus { get; set; }
        public IEnumerable<DocumentModel> listDocument { get; set; }
        public IPagedList<ReplyModel> listReply { get; set; }
        public IPagedList PagingMetaData { get; set; }

        public string actionType {get;set;}

    }
}
