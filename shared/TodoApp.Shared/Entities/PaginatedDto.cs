namespace TodoApp.Shared.Entities;

public class PaginatedDto
{
    public virtual int CurrentPage { get; set; } = 1;
    public virtual int PageSize { get; set; } = 5;
    public virtual int TotalCount { get; set; }
    public virtual int TotalPages => (int)Math.Ceiling(decimal.Divide(TotalCount, PageSize));
    public virtual bool ShowPrevious => CurrentPage > 1;
    public virtual bool ShowNext => CurrentPage < TotalPages;
}
