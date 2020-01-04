using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TJ_Memo
{
    class LocationCtrl
    {
        public static byte[] GetURLContents(string url)
        {
            var content = new MemoryStream();
 
            var webReq = (HttpWebRequest)WebRequest.Create(url);
            webReq.Timeout = 3;
 
            using (WebResponse response = webReq.GetResponse())
            {
                using (Stream responseStream = response.GetResponseStream())
                {
                    responseStream.CopyTo(content);
                }
            }
 
            return content.ToArray();
        }
    }
}
