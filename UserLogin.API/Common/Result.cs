namespace UserLogin.API.Common
{
    public class Result<T>
    {
        public bool IsSuccess { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }

        public static Result<T> Success(T data, string message) => new Result<T> { IsSuccess = true, Data = data, Message = message };

        public static Result<dynamic> Failure(dynamic data, string message) => new Result<dynamic> { IsSuccess = false, Data = data, Message = message };
    }
}
