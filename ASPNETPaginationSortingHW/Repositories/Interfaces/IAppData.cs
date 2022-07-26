using ASPNETPaginationSortingHW.Repositories.Classes;

namespace ASPNETPaginationSortingHW.Repositories.Interfaces
{
    public interface IAppData
    {
        public BookRepository BookRepository { get; }
    }
}
