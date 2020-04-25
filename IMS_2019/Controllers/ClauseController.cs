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
    public class ClauseController : Controller
    {
        ClauseDAL clauseDAL = new ClauseDAL();
        DocumentDAL documentDAL = new DocumentDAL();
        MenuDAL menuDAL = new MenuDAL();
        // GET: /<controller>/
        [HttpGet]
        [Authorize]
        public IActionResult Index(int? page)
        {
            ClauseVM clauseVM = new ClauseVM();
            int pageSize = 10;
            int pageNumber = page ?? 1;
            int totalCount;
            //clauseVM.listClause = new List<ClauseModel>();
            clauseVM.listClause = clauseDAL.GetAllClause(out totalCount).ToPagedList(pageNumber, pageSize);
            clauseVM.PagingMetaData = new StaticPagedList<ClauseModel>(clauseVM.listClause, pageNumber + 1, pageSize, totalCount).GetMetaData();
            
            // GET: /<controller
            return View(clauseVM);
        }

        [Authorize]
        public IActionResult _Detail(string id,string actionType)
        {
            ClauseVM clauseVM = new ClauseVM();
            ClauseModel clauseModel = new ClauseModel();
            if (actionType.ToLower().Equals("insert"))
            {
                // Insert
                clauseVM.actionType = "insert";
                clauseVM.listDocument  = documentDAL.GetAllDocuments();
                clauseVM.listVersion = menuDAL.GetAllVersion();
            }
            else
            {
                // Update
                clauseVM.actionType = "Update";
                clauseVM.clauseModel = clauseDAL.GetClauseById(id);
                clauseVM.listDocument  = documentDAL.GetAllDocuments();
                clauseVM.listVersion = menuDAL.GetAllVersion();
                //clauseModel = clauseDAL.GetDocumentByID(id);
                ////documentVM.listDocument = documentDAL.GetAllDocuments().ToList();
                //documentVM.listDocType = menuDAL.GetAllDocType();
                //documentVM.listVersion = menuDAL.GetAllVersion();
                //documentVM.listDocStatus = menuDAL.GetAllDocStatus();
                //documentVM.documentModel = document;
            }
            return PartialView("_Detail", clauseVM);
        }

        [Authorize]
        [HttpPost]
        public IActionResult InsertClause([FromBody]ClauseModel clauseModel)
        {
            string result = "";
            try
            {
                result = clauseDAL.InsertClause(clauseModel, HttpContext.User.Identity.Name);
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
        public IActionResult UpdateClause([FromBody]ClauseModel clauseModel)
        {
            string result = "";
            try
            {
                result = clauseDAL.UpdateClause(clauseModel, HttpContext.User.Identity.Name);
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
