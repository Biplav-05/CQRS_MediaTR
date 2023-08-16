using System.Text.Json.Serialization;

namespace Application.Common
{
    public class ApiResponse<T>
    {
        public bool isSuccess { get; set; }
        public List<T>? data { get; set; } = new List<T>();

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string? message { get; set; }

        public static ApiResponse<T> AsSuccess(T value)
        {         
            return new ApiResponse<T>
            {
                isSuccess = true,
                data = new List<T> { value}
            };
        }
        public static ApiResponse<T> AsError(string message)
        {
            return new ApiResponse<T>
            {
                isSuccess = false,
                message = message
            };
        }
    }
}
