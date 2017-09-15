using Itcast.CMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itcast.CMS.BLL
{
    public class UserInfoService
    {
        DAL.UserInfoDal UserInfoDal = new DAL.UserInfoDal();
        public UserInfo GetUserInfo(string userName, string userPwd)
        {
            return UserInfoDal.GetUserInfo(userName,userPwd);
        }
    }
}
