using ASPNETPaginationSortingHW.Models;

namespace ASPNETPaginationSortingHW.ViewModels
{
    public class AllBooksViewModel
    {
        public IEnumerable<Book> Items { get; set; }
        public int Count { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int OnPage { get; set; }
        public OrderByEnum OrderBy { get; set; }
        public bool Ascending { get; set; }

        public enum OrderByEnum{
            Id,
            IdDesc,
            Title,
            TitleDesc,
            Price,
            PriceDesc,
            Pages,
            PagesDesc
        }
    }
}
