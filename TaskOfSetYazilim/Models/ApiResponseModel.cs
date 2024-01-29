namespace TaskOfSetYazilim.Models
{
    public class ApiResponseModel
    {
        public bool IsSuccess { get; set; } = true;

        public string Message { get; set; }

        public void AddMessage(string message, bool isSuccess = false)
        {
            Message = message;
            IsSuccess = isSuccess;
        }
    }
}
