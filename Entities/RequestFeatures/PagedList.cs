using Entities.Concretes;

namespace Entities.RequestFeatures;

public class PagedList<T> : List<T>
    where T : Entity, new()
{
    public PagedList(IEnumerable<T> source, int pageNumber, int pageSize, int count)
    {
        MetaData = new MetaData()
        {
            PageNumber = pageNumber,
            PageSize = pageSize,
            TotalCount = count,
            TotalPages = (int)Math.Ceiling(count / (double)pageSize)
        };

        AddRange(source);
    }

    MetaData MetaData { get; set; }

    public static PagedList<T> ToPagedList(IEnumerable<T> source, int pageNumber, int pageSize)
    {
        int count = source.Count();

        var list = source.
            Skip((pageNumber + 1) * pageSize).
            Take(pageSize).
            ToList();

        return new PagedList<T>(list, pageNumber, pageSize, count);
    }
}
