namespace TodoApp.Shared.Responses;

public class DataResponse<T> : IDataResponse<T>
{
    public T Data { get; }
    public bool IsSuccess { get; set; } = true;
    public string Message { get; } = string.Empty;
    public Exception Exception { get; }
    public List<string> Errors { get; set; }

    public DataResponse(T data)
    {
        Data = data;
    }
    public DataResponse(bool isSuccess, T data)
    {
        IsSuccess = isSuccess;
        Data = data;
    }
    public DataResponse(bool isSuccess, string message, T data)
    {
        IsSuccess = isSuccess;
        Message = message;
        Data = data;
    }
    public DataResponse(bool isSuccess, string message, Exception exception, T data)
    {
        IsSuccess = isSuccess;
        Message = message;
        Exception = exception;
        Data = data;
    }
}
