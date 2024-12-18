namespace TodoApp.Shared.Entities;

public class BaseDto
{
    public virtual int CurrentPage { get; set; } = 1;
    public virtual int PageSize { get; set; } = 5;
    public virtual int TotalCount { get; set; }
    public virtual int TotalPages => (int)Math.Ceiling(decimal.Divide(TotalCount, PageSize));
    public virtual bool ShowPrevious => CurrentPage > 1;
    public virtual bool ShowNext => CurrentPage < TotalPages;
    public virtual bool IsSuccess { get; set; } = true;
    public virtual string Message { get; set; } = string.Empty;
}
