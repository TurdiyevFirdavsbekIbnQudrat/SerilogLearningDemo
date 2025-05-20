using Azure;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SerilogLearningDemo
{
    public class ForHttpClient
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly SerilogDb _serilog;

        public ForHttpClient(IHttpContextAccessor httpContextAccessor,SerilogDb serilogDb)
        {
            _httpContextAccessor = httpContextAccessor;

            _serilog = serilogDb;
        }
        public async Task<UserReqAndResHttpClient> GetAll()
        {

            //  var all = await _serilog.Users.ToListAsync();
            var requestHeader = _httpContextAccessor.HttpContext.Request.Headers.ToString();
            var respnseStatus = _httpContextAccessor.HttpContext.Response.StatusCode.ToString();
            var responseBodyPosition = _httpContextAccessor.HttpContext.Response.Body.ToString();
            var responseContentLength = _httpContextAccessor.HttpContext.Response.ContentLength.ToString();
            var responseCookies = _httpContextAccessor.HttpContext.Response.Cookies.ToString();
            var responseStarted = _httpContextAccessor.HttpContext.Response.HasStarted.ToString();
            var responseUserIdentities = _httpContextAccessor.HttpContext.Response.HttpContext.User.Identities.ToString();
            //var responseContentType = _httpContextAccessor.HttpContext.Response.ContentType.ToString();
            var requestAbortedCanbeCanceled = _httpContextAccessor.HttpContext.RequestAborted.CanBeCanceled.ToString();
            var requestRouteValues = _httpContextAccessor.HttpContext.Request.RouteValues.ToString();
            var requestPath = _httpContextAccessor.HttpContext.Request.Path.ToString();
            var requestBodyReader = _httpContextAccessor.HttpContext.Request.BodyReader.ToString();
            //            var requestForm = _httpContextAccessor.HttpContext.Request.Form.ToString();
            //            var requestFormCount = _httpContextAccessor.HttpContext.Request.Form.Count.ToString();

            var requestQueryString = _httpContextAccessor.HttpContext.Request.QueryString.ToString();
            var requestQuery = _httpContextAccessor.HttpContext.Request.Query.ToString();
            var ConnectionLocalIpAddress = _httpContextAccessor.HttpContext.Connection.LocalIpAddress.ToString();
            var ConnectionLocalPort = _httpContextAccessor.HttpContext.Connection.LocalPort.ToString();
            var ConnectionRemotePort = _httpContextAccessor.HttpContext.Connection.RemotePort.ToString();
            var ConnectionRemoteIpAddress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
            //           var ConnectionClientCertificate = _httpContextAccessor.HttpContext.Connection.ClientCertificate.ToString();
            var ConnectionId = _httpContextAccessor.HttpContext.Connection.Id.ToString();
            var Itemskey = _httpContextAccessor.HttpContext.Items.ToList();
            string ItemsKeys ="";
            foreach (var item in Itemskey)
            {
                ItemsKeys = ItemsKeys + item.Key + "=" + item.Value +"                   " ;
            }
            _httpContextAccessor.HttpContext.Session.SetString("Ism","Firdavs");
            var SessionGetString = _httpContextAccessor.HttpContext.Session.GetString("Ism");

            var TraceIdentifier = _httpContextAccessor.HttpContext.TraceIdentifier.ToString();
            
            var res = new UserReqAndResHttpClient()
            {
                request = requestHeader,
                response = respnseStatus,
                responseBodyPosition = responseBodyPosition,
                responseContentLength = responseContentLength,
                responseCookies = responseCookies,
                responseStarted = responseStarted,
                responseUserIdentities = responseUserIdentities,
                requestAbortedCanbeCanceled = requestAbortedCanbeCanceled,
                requestRouteValues = requestRouteValues,
                requestPath = requestPath,
                requestBodyReader = requestBodyReader,
                requestQueryString = requestQueryString,
                requestQuery = requestQuery,
                ConnectionLocalIpAddress = ConnectionLocalIpAddress,
                ConnectionLocalPort = ConnectionLocalPort,
                ConnectionRemotePort = ConnectionRemotePort,
                ConnectionRemoteIpAddress = ConnectionRemoteIpAddress,
                ConnectionId = ConnectionId,
                ItemsKeys= ItemsKeys,
                SessionGetString= SessionGetString,
                TraceIdentifier= TraceIdentifier,
                //       SessionId= SessionId,
                //                ConnectionClientCertificate= ConnectionClientCertificate,
                //      requestForm= requestForm,
                //              requestFormCount = requestFormCount,
                //  responseContentType= responseContentType
                //all = all,
            };
           
            return res;
        }
    }     
}
