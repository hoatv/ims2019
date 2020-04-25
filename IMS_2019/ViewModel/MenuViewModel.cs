using System;
using System.Collections.Generic;
using IMS_2019.Models;
using X.PagedList;

namespace IMS_2019.ViewModel
{
    public class MenuViewModel
    {
        public List<DocStatusModel> listDocStatus = null;
        public List<DocTypeModel> listDocType = null;
        public List<IssStatusModel> listIssStatusModel = null;
        public List<GroupModel> listGroup= null;
        public List<VersionModel> listVersion = null;
        public List<UserModel> listUser = null;
        public string actionType { get; set; }
        public string type { get; set; }
        public IPagedList PagingMetaData { get; set; }
    }
}
