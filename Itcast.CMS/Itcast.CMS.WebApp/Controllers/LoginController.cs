using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Itcast.CMS.BLL;
using Itcast.CMS.Model;
namespace Itcast.CMS.WebApp.Controllers
{
    public class LoginController : Controller
    {
        //约定大于配置
        //
        // GET: /Login/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult UserLogin()
        {
            string validateCode = Session["code"] == null ? string.Empty : Session["code"].ToString();
            if (string.IsNullOrEmpty(validateCode))
            {
                return Content("no:验证码错误!!");
            }
            Session["code"] = null;
            string txtCode = Request["vCode"];
            if (!validateCode.Equals(txtCode, StringComparison.InvariantCultureIgnoreCase))
            {
                return Content("no:验证码错误!!");
            }
            string userName = Request["LoginCode"];
            string userPwd = Request["LoginPwd"];
            UserInfoService UserInfoService = new UserInfoService();
           UserInfo userInfo= UserInfoService.GetUserInfo(userName, userPwd);
           if (userInfo != null)
           {
               //Nginx
               Session["userInfo"] = userInfo;
               return Content("ok:登录成功");
           }
           else
           {
               return Content("no:账号或密码错误!!");
           }
        }

        public ActionResult ShowValidateCode()
        {
            Common.ValidateCode validateCode = new Common.ValidateCode();
            string code=validateCode.CreateValidateCode(4);//获取验证码.
            Session["code"] = code;
           byte[]buffer=validateCode.CreateValidateGraphic(code);
           return File(buffer, "image/jpeg");
        }

    }
}
