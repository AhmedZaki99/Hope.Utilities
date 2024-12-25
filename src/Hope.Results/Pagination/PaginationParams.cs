namespace Hope.Results;

/// <summary>
/// Represents the parameters for paginating a query result.
/// </summary>
public class PaginationParams
{
    private const int MaxPageSize = 150;

    /// <summary>
    /// Gets or sets the number of items per page.
    /// </summary>
    public int PageSize
    {
        get;
        set => field = value > MaxPageSize ? MaxPageSize : value;
    }

    /// <summary>
    /// Gets or sets the current page number.
    /// </summary>
    public int PageNumber
    {
        get;
        set => field = value < 1 ? 1 : value;
    }

    /// <summary>
    /// Gets the offset of the first item in the current page.
    /// </summary>
    public int Offset => (PageNumber - 1) * PageSize;


    /// <summary>
    /// Initializes a new instance of the <see cref="PaginationParams"/> class.
    /// </summary>
    /// <param name="pageNumber">The current page number.</param>
    /// <param name="pageSize">The number of items per page.</param>
    public PaginationParams(int pageNumber = 1, int pageSize = 30)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
    }
}
