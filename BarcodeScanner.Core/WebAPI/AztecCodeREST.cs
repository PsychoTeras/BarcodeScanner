using RestSharp;
using System.Threading.Tasks;

namespace BarcodeScanner.Core.WebAPI
{
    public sealed class AztecCodeREST : BaseRest
    {

#region Ctor

        public AztecCodeREST(string apiUrl) : base(apiUrl)
        {
        }

#endregion

#region Class methods

        private RestRequest BuildPostAztecCodeRequest(string user, string scannedCodeAztec)
        {
            RestRequest request = CreateRequest("AztecBarcode", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddQueryParameter("user", user);
            request.AddQueryParameter("scannedCodeAztec", scannedCodeAztec);
            return request;
        }

        public string PostAztecCodeRequest(string user, string scannedCodeAztec)
        {
            RestRequest request = BuildPostAztecCodeRequest(user, scannedCodeAztec);
            return ExecuteQuery("PostAztecCodeRequest", request);
        }

        public Task<string> PostAztecCodeRequestAsync(string user, string scannedCodeAztec)
        {
            RestRequest request = BuildPostAztecCodeRequest(user, scannedCodeAztec);
            return ExecuteQueryAsync("PostAztecCodeRequest", request);
        }

#endregion

    }
}