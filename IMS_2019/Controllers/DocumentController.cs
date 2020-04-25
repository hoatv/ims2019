using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMS_2019.DAL;
using IMS_2019.Data;
using IMS_2019.Models;
using IMS_2019.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;
//using X.PagedList.Mvc.PagedListExt;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IMS_2019.Controllers
{
    public class DocumentController : Controller
    {
        DocumentDAL documentDAL = new DocumentDAL();
        MenuDAL menuDAL = new MenuDAL();
        // GET: /<controller>/
        [Authorize]
        public IActionResult Index()
        {
            DocumentVM documentVM = new DocumentVM();
            //documentVM.listDocument = documentDAL.GetAllDocuments().ToList();
            //documentVM.listDocType = menuDAL.GetAllDocType();
            //documentVM.listVersion = menuDAL.GetAllVersion();
            //documentVM.listDocStatus = menuDAL.GetAllDocStatus();
            //return View(documentVM);
            //int page = 1;
            int pageSize = 10;
            int totalCount;
            //int pageIndex = 1;
            //pageIndex = page > 0 ? Convert.ToInt32(page) : 1;

            //int pageIndex = 1;
            documentVM.PageNumber =  1;


            documentVM.listDocument = documentDAL.GetAllDocuments(out totalCount).ToPagedList(documentVM.PageNumber, pageSize);
            documentVM.listDocType = menuDAL.GetAllDocType();
            documentVM.listVersion = menuDAL.GetAllVersion();
            documentVM.listDocStatus = menuDAL.GetAllDocStatus();
            return View(documentVM);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Index(int? page)
        {
            DocumentVM documentVM = new DocumentVM();
            int pageSize = 10;
            int pageNumber = page ?? 1;
            //pageIndex = (pageIndex = null) ? 1 : pageIndex;
            int totalCount;

            //documentVM.listDocument = documentDAL.GetAllDocuments().ToPagedList(pageIndex, pageSize);
            documentVM.listDocument = documentDAL.GetAllDocuments(out totalCount).ToPagedList(pageNumber, pageSize);
            //var pageList = (X.PagedList.PagedListExtensions)documentDAL.GetAllDocuments().ToList().ToPagedList(documentVM.PageNumber, pageSize);
            //documentVM.listDocument = (X.PagedList.PagedList(documentVM.listDocument))documentDAL.GetAllDocuments().ToPagedList();
            //documentVM.listDocument = new StaticPagedList<DocumentVM>(documentVM.listDocument, documentVM.PageNumber, pageSize,10);
            documentVM.listDocType = menuDAL.GetAllDocType();
            documentVM.listVersion = menuDAL.GetAllVersion();
            documentVM.listDocStatus = menuDAL.GetAllDocStatus();
            documentVM.PagingMetaData = new StaticPagedList<DocumentModel>(documentVM.listDocument, pageNumber+1, pageSize, totalCount).GetMetaData();
            return View(documentVM);
        }

        [Authorize]
        [HttpPost]
        public IActionResult AddNewDocument([FromBody]DocumentModel document)
        {
            int insertResult = 0;
            try
            {
                // check exists or update Verions
                insertResult = menuDAL.ExistsOrInsertVersion(document, HttpContext.User.Identity.Name);


                //insertResult = documentDAL.InsertDocument(document, HttpContext.User.Identity.Name);
            }
            catch (Exception ex)
            {
                insertResult = 0;
                //throw;
            }
            
            return Json (insertResult);
        }

        [Authorize]
        [HttpPost]
        public IActionResult UpdateDocument([FromBody]DocumentModel document)
        {
            string result = "";
            try
            {
                result = documentDAL.UpdateDocument(document, HttpContext.User.Identity.Name);
            }
            catch (Exception)
            {
                result = "fail";
                //throw;
            }

            return Json(result);
        }

        [Authorize]
        public IActionResult _Detail(string id)
        {
            DocumentVM documentVM = new DocumentVM();
            DocumentModel document = new DocumentModel();
            document = documentDAL.GetDocumentByID(id);
            //documentVM.listDocument = documentDAL.GetAllDocuments().ToList();
            documentVM.listDocType = menuDAL.GetAllDocType();
            documentVM.listVersion = menuDAL.GetAllVersion();
            documentVM.listDocStatus = menuDAL.GetAllDocStatus();
            documentVM.documentModel = document;
            return PartialView("_Detail", documentVM);
        }
    }
}
