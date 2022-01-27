using System.Collections.Generic;

namespace UserLogin.API.Common
{
    public static class Responses<T>
    {
        public static Result<T> SuccessResult(T data)
        {
            return Result<T>.Success(data, null);
        }
        public static Result<T> SuccessResult(T data,string message)
        {
            return Result<T>.Success(data, message);
        }
        public static Result<dynamic> ApplicationErrorMessage()
        {
            return Result<dynamic>.Failure(null, message: "A internal server error ocurred");
        }

        public static Result<dynamic> DomainErrorMessage(string message)
        {
            return Result<dynamic>.Failure(null, message);
        }

        public static Result<dynamic> DomainErrorMessage(string message, IReadOnlyList<string> errors)
        {
            return Result<dynamic>.Failure(errors, message);
        }

        public static Result<dynamic> UnauthorizedErrorMessage()
        {
            return Result<dynamic>.Failure(null, "Invalid username or password");
        }
    }
}
