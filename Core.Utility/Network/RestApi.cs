using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utility.Network
{
    public static class RestApi
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bseeUri">e.g. http://xxxx.com.tw/v1/api</param>
        /// <param name="path">rest api resource path. e.g. dashboard/{id}</param>
        public static async Task<T> GetAsync<T>(string baseUri, string path) where T : new()
        {
            var request = new RestRequest(path, Method.GET);

            // easily add HTTP Headers
            // request.AddHeader("header", "value");

            return await ExecuteAsync<T>(new Uri(baseUri), request);
        }

        public static async Task<T> ExecuteAsync<T>(Uri uri, RestRequest request) where T : new()
        {
            return await ExecuteAsync<T>(uri, request, null, null);
        }

        public static async Task<T> ExecuteAsync<T>(Uri uri, RestRequest request, string account, string password) where T : new()
        {
            var client = new RestClient();
            client.BaseUrl = uri;
            // account info
            if (account != null && password != null)
                client.Authenticator = new HttpBasicAuthenticator(account, password);

            var response = await client.ExecuteTaskAsync<T>(request);

            if (response.ErrorException != null)
            {
                const string message = "Error retrieving response.  Check inner details for more info.";
                var exception = new ApplicationException(message, response.ErrorException);
                throw exception;
            }
            return response.Data;
        }
    }
}
