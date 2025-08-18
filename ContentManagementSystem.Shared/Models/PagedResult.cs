namespace ContentManagementSystem.Shared.Models
{
    public class PagedResult <T>
    {
        public List<T> Data { get; set; } = new List<T>();
        public int Pages { get; set; }
        public int CurrentPage { get; set; }
    }
}
