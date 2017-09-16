using Itcast.CMS.BLL;
using Itcast.CMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Itcast.CMS.WebApp.Controllers
{
    public class NewsListController : Controller
    {
        // GET: NewsList
        NewsInfoService NewsInfoService=new NewsInfoService();
        public ActionResult Index()
        {
            int pageIndex = Request["pageIndex"] != null ? int.Parse(Request["pageIndex"]) : 1;
            int pageSize = 5;
            int pageCount = NewsInfoService.GetPageCount(pageSize);
            pageIndex = pageIndex < 1 ? 1 : pageIndex;
            pageIndex = pageIndex > pageCount ? pageCount : pageIndex;
            List<NewsInfo> list = NewsInfoService.GetPageList(pageIndex,pageSize);
            ViewData["list"] = list;
            ViewBag.PageIndex = pageIndex;
            ViewBag.PageCount = pageCount;
            return View();
        }

        public ActionResult ShowDetail()
        {
            int id = int.Parse(Request["id"]);
            NewsInfo newsInfo = NewsInfoService.GetModel(id);
            ViewData.Model = newsInfo;
            return View();
        }

    }
}