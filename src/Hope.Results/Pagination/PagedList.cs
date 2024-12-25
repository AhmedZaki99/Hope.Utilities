namespace Hope.Results;

/// <summary>
/// Represents a page of items from a paginated query result.
/// </summary>
/// <typeparam name="T">The type of items in the page.</typeparam>
public class PagedList<T>
{
    /// <summary>
    /// Gets or sets a list of the items in the current page.
    /// </summary>
    public List<T> Items { get; set; } = [];


    /// <summary>
    /// Gets or sets the total number of items in the query result.
    /// </summary>
    public int TotalCount { get; set; }

    /// <summary>
    /// Gets or sets the current page number.
    /// </summary>
    public int PageNumber { get; set; }

    /// <summary>
    /// Gets or sets the number of items per page.
    /// </summary>
    public int PageSize { get; set; }


    /// <summary>
    /// Gets the total number of pages in the query result.
    /// </summary>
    public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);

    /// <summary>
    /// Gets a value indicating whether there is a previous page.
    /// </summary>
    public bool HasPreviousPage => PageNumber > 1;

    /// <summary>
    /// Gets a value indicating whether there is a next page.
    /// </summary>
    public bool HasNextPage => PageNumber < TotalPages;
}
