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
    public class IssueController : Controller
    {
        IssueDAL issueDAL = new IssueDAL();
        ClauseIssueDAL clauseIssueDAL = new ClauseIssueDAL();
        MenuDAL menuDAL = new MenuDAL();
        ClauseDAL clauseDAL = new ClauseDAL();
        // GET: /<controller>/
        //[Authorize]
        public IActionResult Index(int? page)
        {
            IssueVM issueVM = new IssueVM();
            int pageSize = 10;
            int pageNumber = page ?? 1;
            int totalCount;
            //clauseDAL.GetAllClause(out totalCount).ToPagedList(pageNumber, pageSize);
            issueVM.listIssue = issueDAL.GetAllIssue(out totalCount).ToPagedList(pageNumber, pageSize);
            issueVM.PagingMetaData = new StaticPagedList<IssueModel>(issueVM.listIssue, pageNumber + 1, pageSize, totalCount).GetMetaData();

            //issueVM.listIssStatus = menuDAL.GetAllIssStatusTest().ToList();

            return View(issueVM);
        }


        [Authorize]
        public IActionResult _Detail(string id, string actionType)
        {
            IssueVM issueVM = new IssueVM();
            IssueModel issueModel = new IssueModel();
            if (actionType.ToLower().Equals("insert"))
            {
                // Insert
                issueVM.actionType = "insert";
                issueVM.listIssStatus = menuDAL.GetAllIssStatus().ToList();
                issueVM.listClauseIssue = clauseIssueDAL.GetAllClauseIssue().ToList();
                issueVM.listClause = clauseDAL.GetAllClause().ToList();
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
                issueVM.actionType = "update";
                issueVM.issModel = issueDAL.GetIssueByID(id);
                issueVM.listIssStatus = menuDAL.GetAllIssStatus().ToList();
                issueVM.listClauseIssue = clauseIssueDAL.GetAllClauseIssue().ToList();
                issueVM.listClause = clauseDAL.GetAllClause().ToList();
            }
            return PartialView("_Detail", issueVM);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Insert([FromBody]IssueModel issueModel)
        {
            string result = "";
            try
            {
                result = issueDAL.Insert(issueModel, HttpContext.User.Identity.Name);
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
        public IActionResult Update([FromBody]IssueModel issueModel)
        {
            string result = "";
            try
            {
                result = issueDAL.Update(issueModel, HttpContext.User.Identity.Name);
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
