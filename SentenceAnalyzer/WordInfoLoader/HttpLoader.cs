using System.Collections.Specialized;
using System.Net;
using System.Text;

namespace WordInfoLoader
{
    class HttpLoader
    {
        public static string LoadData(string url, string urlReferer, string word)
        {
            using (var wb = new WebClient())
            {
                wb.Headers.Add("Referer", urlReferer);
                var data = new NameValueCollection();

                data["word"] = word;
                var response = wb.UploadValues(url, "POST", data);
                return Encoding.UTF8.GetString(response);
            }
        }
    }
}
