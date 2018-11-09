using IPCLogger.Core.Common;
using IPCLogger.Core.Loggers.LFactory;
using System;
using System.Activities;
using System.Net;
using System.Net.Http;
using System.Web.Hosting;
using System.Web.Http;

namespace BarcodeScanner.WebAPI.Controllers
{
    class ScannedCodeAztecResult
    {
        public DateTime AcceptDate;

        public string Result;

        public string Message;

        public static ScannedCodeAztecResult Successful(string message)
        {
            return new ScannedCodeAztecResult
            {
                AcceptDate = DateTime.Now,
                Result = "Successful",
                Message = message
            };
        }
    }

    public class AztecBarcodeController : ApiController
    {
        private void AssertPostData(string user, string scannedCodeAztec)
        {
            if (string.IsNullOrWhiteSpace(user))
            {
                throw new ValidationException("Invalid user");
            }
            if (string.IsNullOrWhiteSpace(scannedCodeAztec))
            {
                throw new ValidationException("Invalid scannedCodeAztec");
            }
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok("Test passed");
        }

        [HttpPost]
        public IHttpActionResult Create(string user, string scannedCodeAztec)
        {
            try
            {
                AssertPostData(user, scannedCodeAztec);
                string outInfo = user + "/" + scannedCodeAztec;
                LFactory.Instance.WriteLine(outInfo);

                return Ok(ScannedCodeAztecResult.Successful(outInfo));
            }
            catch (ValidationException ex)
            {
                LFactory.Instance.WriteLine(LogEvent.Error, ex, "ValidationException");
                HttpResponseMessage errRsp = Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
                throw new HttpResponseException(errRsp);
            }
            catch (Exception ex)
            {
                LFactory.Instance.WriteLine(LogEvent.Error, ex, "Exception");
                HttpResponseMessage errRsp = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
                throw new HttpResponseException(errRsp);
            }
        }
    }
}