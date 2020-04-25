using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMS_2019.DAL;
using IMS_2019.Models;
using IMS_2019.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IMS_2019.Controllers
{
    public class MenuController : Controller
    {
        MenuDAL menuDAL = new MenuDAL();
        // GET: /<controller>/
        //[Authorize]
        public IActionResult Index(string id)
        {
            MenuViewModel menuViewModel = new MenuViewModel();
            switch (id)
            {
                case("doc_status"):
                    List<DocStatusModel> listDocStatusModel = new List<DocStatusModel>();
                    listDocStatusModel = menuDAL.GetAllDocStatus().ToList();
                    menuViewModel.listDocStatus = new List<DocStatusModel>();
                    menuViewModel.listDocStatus = listDocStatusModel;
                    ViewBag.Title = "List Doc Status";
                    menuViewModel.type = id;
                    return View(menuViewModel);
                case ("doc_type"):
                    List<DocTypeModel> listDocType = new List<DocTypeModel>();
                    listDocType = menuDAL.GetAllDocType().ToList();
                    menuViewModel.listDocType = new List<DocTypeModel>();
                    menuViewModel.listDocType = listDocType;
                    ViewBag.Title = "List Doc Type";
                    menuViewModel.type = "doctype";
                    return View(menuViewModel);

                case ("issstatus"):
                    List<IssStatusModel> listIssStatusModel = new List<IssStatusModel>();
                    listIssStatusModel = menuDAL.GetAllIssStatus().ToList();
                    menuViewModel.listIssStatusModel = new List<IssStatusModel>();
                    menuViewModel.listIssStatusModel = listIssStatusModel;
                    ViewBag.Title = "List Issue Status";
                    menuViewModel.type = id;
                    return View(menuViewModel);
                case ("group"):
                    List<GroupModel> listGroupModel = new List<GroupModel>();
                    listGroupModel = menuDAL.GetAllGroup().ToList();
                    menuViewModel.listGroup = new List<GroupModel>();
                    menuViewModel.listGroup = listGroupModel;
                    ViewBag.Title = "List Group";
                    menuViewModel.type = id;
                    return View(menuViewModel);
                case ("version"):
                    List<VersionModel> listVersionModel = new List<VersionModel>();
                    listVersionModel = menuDAL.GetAllVersion().ToList();
                    menuViewModel.listVersion = new List<VersionModel>();
                    menuViewModel.listVersion = listVersionModel;
                    ViewBag.Title = "List Version";
                    menuViewModel.type = id;
                    return View(menuViewModel);
                case ("user"):
                    List<UserModel> listUserModel = new List<UserModel>();
                    listUserModel = menuDAL.GetAllUser().ToList();
                    menuViewModel.listUser = new List<UserModel>();
                    menuViewModel.listUser = listUserModel;
                    ViewBag.Title = "List User";
                    menuViewModel.type = id;
                    return View(menuViewModel);
                default:
                    break;
            }
            return View();
        }
    }
}
