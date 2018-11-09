using System;
using System.Net;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;

namespace BarcodeScanner.Core.WebAPI
{
    public abstract class BaseRest
    {

#region Private fields

        private readonly string _userName;
        private readonly string _password;
        private HttpBasicAuthenticator _auth;
        private NetworkCredential _authWeb;

#endregion

#region Properties

        public string HostUrl { get; }

        protected IRestClient Client
        {
            get
            {
                return new RestClient(HostUrl)
                {
                    Authenticator = _auth,
                };
            }
        }


        protected WebClient WebClient
        {
            get
            {
                return new WebClient
                {
                    Credentials = _authWeb,
                };
            }
        }

#endregion

#region Ctor

        private void AssertCtor(string hostUrl)
        {
            if (string.IsNullOrEmpty(hostUrl))
            {
                throw new ArgumentException("Host URL is not defined", hostUrl);
            }
        }

        protected BaseRest(string hostUrl)
        {
            AssertCtor(HostUrl = hostUrl);   
            _userName = string.Empty;
            _password = string.Empty;
            if (!string.IsNullOrEmpty(_userName))
            {
                _auth = new HttpBasicAuthenticator(_userName, _password);
                _authWeb = new NetworkCredential(_userName, _password);
            }
        }

#endregion

#region Protected

        protected RestRequest CreateRequest(string @params, Method method)
        {
            RestRequest request = new RestRequest(@params, method);
            return request;
        }

        protected RestRequest CreateRequest(Method method)
        {
            return CreateRequest(string.Empty, method);
        }

        protected string ExecuteQuery(string method, RestRequest request)
        {
            IRestResponse response = Client.Execute(request);
            return response.Content;
        }

        protected Task<string> ExecuteQueryAsync(string method, RestRequest request)
        {
            TaskCompletionSource<string> tcs = new TaskCompletionSource<string>();
            Client.ExecuteAsync(request, response => { tcs.SetResult(response.Content); });
            return tcs.Task;
        }

#endregion

    }
}