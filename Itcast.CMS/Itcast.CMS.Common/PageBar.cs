using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itcast.CMS.Common
{
    public class PageBar
    {
        public static string GetPageBar(int pageIndex,int pageCount)
        {
            if (pageCount==1) {
                return string.Empty;
            }
            int start = pageIndex - 5;
            if (start<1)
            {
                start = 1;
            }
            int end = start + 9;
            if (end > pageCount)
            {
                end = pageCount;
            }
            StringBuilder sb = new StringBuilder();
            for (int i = start;i<=end;i++)
            {
                if (i == pageIndex)
                {
                    sb.Append(i);
                }
                else
                {
                    sb.Append(string.Format("<a href='?pageIndex={0}'>{0}</a>",i));
                }
            }
            return sb.ToString();

        }
    }
}
