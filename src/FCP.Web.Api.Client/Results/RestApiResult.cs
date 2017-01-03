using System.Net;

namespace FCP.Web.Api.Client
{
    public class RestApiResult
    {
        public HttpStatusCode code { get; set; }

        /// <summary>
        /// 成功或者失败标志
        /// </summary>
        public bool flag { get; set; }

        /// <summary>
        /// 返回消息
        /// </summary>
        public string msg { get; set; }
    }

    public class RestApiResult<T> : RestApiResult
    {
        /// <summary>
        /// 返回数据
        /// </summary>
        public T data { get; set; }
    }
}
