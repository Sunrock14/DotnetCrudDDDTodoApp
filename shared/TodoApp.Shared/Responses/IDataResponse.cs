namespace TodoApp.Shared.Responses;

public interface IDataResponse<out T>
{
    public T Data { get; }
}
