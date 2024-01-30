namespace TaskOfSetYazilim.Models
{
    public class ApiResponseModel<T>
    {
        public bool IsSuccess { get; set; } = true;

        public string Message { get; set; }
        public T Data { get; set; }
        public void AddMessage(string message, bool isSuccess = false)
        {
            Message = message;
            IsSuccess = isSuccess;
        }
    }
}
