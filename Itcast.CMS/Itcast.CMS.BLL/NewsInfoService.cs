using Itcast.CMS.DAL;
using Itcast.CMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itcast.CMS.BLL
{
    public class NewsInfoService
    {
        NewsInfoDal NewsInfoDal = new NewsInfoDal();
        public List<NewsInfo> GetPageList(int pageIndex,int pageSize)
        {
            int start = (pageIndex - 1) * pageSize + 1;
            int end = pageIndex * pageSize;
            List<NewsInfo> list = NewsInfoDal.GetPageList(start,end);
            return list;
        }

        public int GetPageCount(int pageSize)
        {
            int recordCount = NewsInfoDal.GetRecordCount();
            int pageCount=Convert.ToInt32(Math.Ceiling((double)recordCount / pageSize));
            return pageCount;
        }
        public NewsInfo GetModel(int id)
        {
            return NewsInfoDal.GetModel(id);
        }

        public bool DeleteInfo(int id)
        {
            return NewsInfoDal.DeleteInfo(id)>0;
        }

    }
}
