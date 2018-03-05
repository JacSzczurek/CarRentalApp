namespace CarRentalApp.Controllers.Resources
{
    public interface IQueryObject
    {
        bool IsAscending { get; set; }
        int Page { get; set; }
        int PageSize { get; set; }
        string SortBy { get; set; }
    }
}