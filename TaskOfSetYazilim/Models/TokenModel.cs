using System.Net;

namespace TaskOfSetYazilim.Models
{
    public class TokenModel
    {
        public string Token { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public HttpStatusCode Code { get; set; }
        public void AddMessage(string message, bool isSuccess = false, HttpStatusCode code=HttpStatusCode.Unauthorized)
        {
            Message = message;
            IsSuccess = isSuccess;
            Code = code;    
        }
    }
}
