using ASPNETPaginationSortingHW.Models;
using ASPNETPaginationSortingHW.ViewModels;
using static ASPNETPaginationSortingHW.ViewModels.AllBooksViewModel;

namespace ASPNETPaginationSortingHW.Services.Interfaces
{
    public interface IBookService
    {
        Task<AllBooksViewModel> GetAll(int page = 1, int count = 12, OrderByEnum orderBy = OrderByEnum.Id);
        Task<Book> GetById(int id);
        Task<int> Add(Book book);
        Task<int> Edit(Book book);
        Task<int> Delete(int id);
    }
}
