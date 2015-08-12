using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace Pikabu_BestComment
{
    public static class Utils
    {
        public static string getWebPage(string url)
        {
            string result = null;
            Uri uri = new Uri(url);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            if (response.StatusCode != HttpStatusCode.OK)
            {
                response.Close();
                throw new Exception(String.Format("Pikabu вернул плохой ответ: {0}", response.StatusCode));
            }
            using(StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding(response.CharacterSet)))
            {
                result = reader.ReadToEnd();
            }
            return result;
        }

        public static string cleanString(string str)
        {
            string result = str.Replace("\n", "").Replace("\t", "");
            result = result.Replace("\r", "").Replace("\b", "");
            return result.Trim();
        }
    }
}
