using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelperFunctions;
using WebSpider;
using System.Net;
using Newtonsoft;

namespace YandexAPI
{
    public class Main : ApiInterface, IDisposable
    {
        public Main()
        {
            spider = new Spider();
        }

        public Main(string languageToTranslate, string sourse)
        {
            spider = new Spider();
            this.To = languageToTranslate;
            this.Sourse = sourse;
        }

        private string baseUrl = "https://translate.yandex.net/api/v1.5/tr.json/";
        private int maxSourseLength = 10000;

        /// <summary>
        /// Post type by default.
        /// </summary>
        private Spider spider;

        private string _key = "trnsl.1.1.20130929T041639Z.20fd979f83019e1a.af491e7ba5667bbcb8fd32203ba593fe5078cb9e";
        public string ApiKey
        {
            get
            {
                return this._key;
            }
            set
            {
                this._key = value;
            }
        }

        public string From
        { get; set; }
        public string To
        {
            get;
            set;
        }

        public string Result { get; set; }
        public string Sourse { get; set; }

        public void GetResult()
        {
            string responseString = this.GetResponseString();
            if (!responseString.IsNullOrWhiteSpace())
            {
                try
                {
                    YandexJSON jsonObj = JSONHelper.FromJSON<YandexJSON>(responseString);

                    if (jsonObj != null && jsonObj.text != null)
                    {
                        this.Result = "";

                        jsonObj.text.ForEach(str => this.Result = this.Result.AppendString(str));
                    }
                }
                catch (Exception e)
                {
                    throw new Exception(string.Format("Error occurred while parsing JSON string [sourse = ]", responseString));
                }
            }
        }

        private string GetResponseString()
        {
            KeyValuePair<Uri, string> urlWithPostParamsToRequest = this.BuildPostRequestUrl();

            if (!urlWithPostParamsToRequest.Key.AbsoluteUri.IsNullOrWhiteSpace())
            {
                spider.Url = urlWithPostParamsToRequest.Key.OriginalString;
                spider.Type = HTTPRequestType.Post;
                spider.PostVars = urlWithPostParamsToRequest.Value.Replace("?", "");

                return SpiderExtentions.GetResponseText(ref spider);
            }

            return null;
        }

        private KeyValuePair<Uri, string> BuildPostRequestUrl()
        {
            if (this._key.IsNullOrWhiteSpace())
                throw new ArgumentNullException("Api key can not be null or empty.");

            if (this.To.IsNullOrWhiteSpace())
                throw new ArgumentException("Set up language to tranlate.");

            if (this.Sourse.IsNullOrWhiteSpace())
                throw new ArgumentException("Please, enter sourse text.");

            Uri uriToRequest = new Uri("https://translate.yandex.net/api/v1.5/tr.json/translate");
            if (uriToRequest != null)
            {
                QueryStringBuilder builder = new QueryStringBuilder();

                builder.SetValue("text", this.Sourse);
                builder.SetValue("lang", this.To);
                builder.SetValue("key", this._key);

                return new KeyValuePair<Uri, string>(uriToRequest, builder.ToString());
            }

            return new KeyValuePair<Uri, string>();
        }

        private bool isValid()
        {


            return false;
        }

        public void Dispose()
        {
            _key = this.ApiKey = null;
        }
    }
}
