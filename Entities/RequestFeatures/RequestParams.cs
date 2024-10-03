namespace Entities.RequestFeatures;

public abstract class RequestParams
{
    private const int _maxPageSize = 50;

    private int _pageSize;

    public int PageSize
    {
        get { return _pageSize; }
        set { _pageSize = value > _maxPageSize ? _maxPageSize : value; }
    }

    public int PageNumber { get; set; }

    public string? Fields { get; set; }

    public DateTime? MaxCreatedDate { get; set; }

    public DateTime? MinCreatedDate { get; set; }
}
