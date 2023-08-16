namespace Application.Common
{
    public class ValidationErrorHandler<T> : Exception
    {
        public string _errorMessage;
        public ValidationErrorHandler(string errorMessage)
        {
             _errorMessage = errorMessage;
            //ValidationError(errorMessage);
        }

        public ApiResponse<T> ValidationError()
        {
            return ApiResponse<T>.AsError(_errorMessage);
        }
        
    }
}
