﻿using System.Collections.Generic;
using System.Text;

namespace Tangent.Core
{
    public class WebHelper : IWebHelper
    {

        public WebHelper()
        {
        }
        //public WebHelper(IHttpContextAccessor accessor)
        //{
        //    this._httpContext = accessor.HttpContext;
        //}

        public virtual string ModifyUrl(string url, string queryStringModification)
        {
            if (url == null)
                url = string.Empty;

            if (queryStringModification == null)
                queryStringModification = string.Empty;

            string str = string.Empty;
            string str2 = string.Empty;
            if (url.Contains("?"))
            {
                str = url.Substring(url.IndexOf("?") + 1);
                url = url.Substring(0, url.IndexOf("?"));
            }
            if (!string.IsNullOrEmpty(queryStringModification))
            {
                if (!string.IsNullOrEmpty(str))
                {
                    var dictionary = new Dictionary<string, string>();
                    foreach (string str3 in str.Split(new char[] { '&' }))
                    {
                        if (!string.IsNullOrEmpty(str3))
                        {
                            string[] strArray = str3.Split(new char[] { '=' });
                            if (strArray.Length == 2)
                            {
                                dictionary[strArray[0]] = strArray[1];
                            }
                            else
                            {
                                dictionary[str3] = null;
                            }
                        }
                    }
                    foreach (string str4 in queryStringModification.Split(new char[] { '&' }))
                    {
                        if (!string.IsNullOrEmpty(str4))
                        {
                            string[] strArray2 = str4.Split(new char[] { '=' });
                            if (strArray2.Length == 2)
                            {
                                dictionary[strArray2[0]] = strArray2[1];
                            }
                            else
                            {
                                dictionary[str4] = null;
                            }
                        }
                    }
                    var builder = new StringBuilder();
                    foreach (string str5 in dictionary.Keys)
                    {
                        if (builder.Length > 0)
                        {
                            builder.Append("&");
                        }
                        builder.Append(str5);
                        if (dictionary[str5] != null)
                        {
                            builder.Append("=");
                            builder.Append(dictionary[str5]);
                        }
                    }
                    str = builder.ToString();
                }
                else
                {
                    str = queryStringModification;
                }
            }
            return (url + (string.IsNullOrEmpty(str) ? "" : ("?" + str)) + (string.IsNullOrEmpty(str2) ? "" : ("#" + str2)));
        }

        //public Uri GetThisPageUrl()
        //{
        //    var request = _httpContext.Request;
        //    UriBuilder uriBuilder = new UriBuilder();
        //    uriBuilder.Scheme = request.Scheme;
        //    uriBuilder.Host = request.Host.Host;
        //    uriBuilder.Path = request.Path.ToString();
        //    uriBuilder.Query = request.QueryString.ToString();
        //    return uriBuilder.Uri;
        //}

    }
}
