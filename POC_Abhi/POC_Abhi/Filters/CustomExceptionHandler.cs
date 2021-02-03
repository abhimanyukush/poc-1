using DataAccessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using POC_Abhi.Exceptions;
using System.Net;

namespace POC_Abhi.Filters
{
    /// <summary>  
    /// This method will automatically trigger when any exception occurs in application level.  
    /// </summary>  
    /// <param name="context"></param>
    public class CustomExceptionHandler : IExceptionFilter
    {
        CustomException customException = new CustomException();
        public void OnException(ExceptionContext context)
        {
            HttpStatusCode statusCode = (context.Exception as WebException != null &&
                        ((HttpWebResponse)(context.Exception as WebException).Response) != null) ?
                         ((HttpWebResponse)(context.Exception as WebException).Response).StatusCode
                         : customException.getErrorCode(context.Exception.GetType());
            string errorMessage = context.Exception.Message;
            string customErrorMessage = Constant.ERRORMSG;
            string stackTrace = context.Exception.StackTrace;

            HttpResponse response = context.HttpContext.Response;
            response.StatusCode = (int)statusCode;
            response.ContentType = "application/json";
            var result = JsonConvert.SerializeObject(
                new
                {
                    message = customErrorMessage,
                    isError = true,
                    errorMessage = errorMessage,
                    errorCode = statusCode,
                    model = string.Empty
                });
            #region Logging  
            //if (ConfigurationHelper.GetConfig()[ConfigurationHelper.environment].ToLower() != "dev")  
            //{  
            //    LogMessage objLogMessage = new LogMessage()  
            //    {  
            //        ApplicationName = ConfigurationHelper.GetConfig()["ApplicationName"].ToString(),  
            //        ComponentType = (int) ComponentType.Server,  
            //        ErrorMessage = errorMessage,  
            //        LogType = (int) LogType.EventViewer,  
            //        ErrorStackTrace = stackTrace,  
            //        UserName = Common.GetAccNameDev(context.HttpContext)  
            //    };  
            //    LogError(objLogMessage, LogEntryType.Error);  
            //}  
            #endregion Logging  
            response.ContentLength = result.Length;
            response.WriteAsync(result);
        }
    }
}
