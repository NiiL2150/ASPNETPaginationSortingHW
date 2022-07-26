using ASPNETPaginationSortingHW.Repositories.Interfaces;

namespace ASPNETPaginationSortingHW.Repositories.Classes
{
    public class AppData : IAppData
    {
        private readonly BookRepository _bookRepository;

        public BookRepository BookRepository => _bookRepository ?? new();
    }
}
