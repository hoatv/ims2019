using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMS_2019.DAL;
using IMS_2019.Models;
using IMS_2019.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IMS_2019.Controllers
{
    public class ReplyController : Controller
    {
        ReplyDAL replyDAL = new ReplyDAL();
        ClauseIssueDAL clauseIssueDAL = new ClauseIssueDAL();
        IssueDAL issueDAL = new IssueDAL();
        MenuDAL menuDAL = new MenuDAL();

        // GET: /<controller>/
        [Authorize]
        public IActionResult Index(int? page)
        {
            //List<ReplyModel> listReply = new List<ReplyModel>();
            //listReply = replyDAL.GetAllReply().ToList();
            //return View(listReply);
            ReplyVM replyVM = new ReplyVM();
            int pageSize = 10;
            int pageNumber = page ?? 1;
            int totalCount;
            replyVM.listReply = replyDAL.GetAllReply(out totalCount).ToPagedList(pageNumber, pageSize);
            replyVM.PagingMetaData = new StaticPagedList<ReplyModel>(replyVM.listReply, pageNumber + 1, pageSize, totalCount).GetMetaData();
            return View(replyVM);
        }

        [Authorize]
        public IActionResult _Detail(string id, string actionType)
        {
            ReplyVM replyVM = new ReplyVM();
            ReplyModel replyModel = new ReplyModel();
            if (actionType.ToLower().Equals("insert"))
            {
                // Insert
                replyVM.actionType = "insert";
                replyVM.listClauseIssueModels = clauseIssueDAL.GetAllClauseIssue();
                replyVM.listIssue = issueDAL.GetAllIssues();
                replyVM.listClauseIssueModels = clauseIssueDAL.GetAllClauseIssue();
                //replyVM.listIssue =
                //replyVM.listClauseIssue = clauseIssueDAL.GetAllClauseIssue().ToList();
                //replyVM.listClause = clauseDAL.GetAllClause().ToList();
                //GetAllClause
            }
            else
            {
                // Update
                //clauseVM.actionType = "Update";
                //clauseVM.clauseModel = clauseDAL.GetClauseById(id);
                //clauseVM.listDocument = documentDAL.GetAllDocuments();
                //clauseVM.listVersion = menuDAL.GetAllVersion();
                //clauseModel = clauseDAL.GetDocumentByID(id);
                ////documentVM.listDocument = documentDAL.GetAllDocuments().ToList();
                //documentVM.listDocType = menuDAL.GetAllDocType();
                //documentVM.listVersion = menuDAL.GetAllVersion();
                //documentVM.listDocStatus = menuDAL.GetAllDocStatus();
                //documentVM.documentModel = document;
                replyVM.actionType = "update";
                replyVM.replyModel = replyDAL.GetReplyByID(id);
                replyVM.listClauseIssueModels = clauseIssueDAL.GetAllClauseIssue();
                replyVM.listIssue = issueDAL.GetAllIssues();
            }
            return PartialView("_Detail", replyVM);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Insert([FromBody]ReplyModel replyModel)
        {
            string result = "";
            try
            {
                result = replyDAL.Insert(replyModel, HttpContext.User.Identity.Name);
            }
            catch (Exception)
            {
                result = "fail";
                //throw;
            }

            return Json(result);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Update([FromBody]ReplyModel replyModel)
        {
            string result = "";
            try
            {
                result = replyDAL.Update(replyModel, HttpContext.User.Identity.Name);
            }
            catch (Exception)
            {
                result = "fail";
                //throw;
            }

            return Json(result);
        }
    }
}
