using Itcast.CMS.BLL;
using Itcast.CMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Itcast.CMS.WebApp.Controllers
{
    public class AdminNewsListController : Controller
    {
        NewsInfoService NewsInfoService = new NewsInfoService();

        #region 分页列表
        // GET: AdminNewsList
        public ActionResult Index()
        {
            int pageIndex = Request["pageIndex"] != null ? int.Parse(Request["pageIndex"]) : 1;
            int pageSize = 5;
            int pageCount = NewsInfoService.GetPageCount(pageSize);
            pageIndex = pageIndex < 1 ? 1 : pageIndex;
            pageIndex = pageIndex > pageCount ? pageCount : pageIndex;
            List<NewsInfo> list = NewsInfoService.GetPageList(pageIndex, pageSize);//获取分页的数据
            ViewData["list"] = list;
            ViewData["pageIndex"] = pageIndex;
            ViewData["pageCount"] = pageCount;
            return View();
        }
        #endregion

        #region 获取详细记录
        public ActionResult GetNewsInfoModel()
        {
            int id = int.Parse(Request["id"]);
            NewsInfo newsInfo=NewsInfoService.GetModel(id);
            return Json(newsInfo,JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 删除一条新闻
        public ActionResult DeleteNewsInfo()
        {
            int id = int.Parse(Request["id"]);
            if (NewsInfoService.DeleteInfo(id))
            {
                return Content("ok");
            }
            else
            {
                return Content("no");
            }
        }
        #endregion

        #region 展示添加新闻的表单页面
        public ActionResult ShowAddInfo()
        {
            return View();
        }
        #endregion
    }
}