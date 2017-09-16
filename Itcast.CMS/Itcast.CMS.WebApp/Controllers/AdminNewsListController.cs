using Itcast.CMS.BLL;
using Itcast.CMS.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Itcast.CMS.WebApp.Controllers
{
    public class AdminNewsListController : BaseController//Controller
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

        #region 图片文件上传
        public ActionResult FileUpload()
        {
            HttpPostedFileBase postFile = Request.Files["fileUp"];//接受文件数据
            if (postFile == null)
            {
                return Content("no:请选择上传文件");
            }
            else
            {
                string fileName = Path.GetFileName(postFile.FileName);//获取文件名
                string fileExt = Path.GetExtension(fileName);//文件的扩展名称
                if (fileExt == ".jpg")
                {
                    string dir = "/ImagePath/" + DateTime.Now.Year + "/" + DateTime.Now.Month + "/" + DateTime.Now.Day + "/";
                    Directory.CreateDirectory(Path.GetDirectoryName(Request.MapPath(dir)));//创建文件夹
                    string newfileName = Guid.NewGuid().ToString();//新的文件名
                    string fullDir = dir + newfileName + fileExt;//完整的路径
                    postFile.SaveAs(Request.MapPath(fullDir));//保存文件
                    return Content("ok:" + fullDir);
                }
                else
                {
                    return Content("no:文件格式错误！！");
                }
            }
        }
        #endregion

        #region 添加新闻
        [ValidateInput(false)]
        public ActionResult AddNewsInfo(NewsInfo newsInfo)
        {
            newsInfo.SubDateTime = DateTime.Now;
            if (NewsInfoService.AddInfo(newsInfo))
            {
                return Content("ok");
            }
            else
            {
                return Content("no");
            }
        }
        #endregion
    }
}