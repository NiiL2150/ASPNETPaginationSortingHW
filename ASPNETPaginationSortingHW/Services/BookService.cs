using ASPNETPaginationSortingHW.Models;
using ASPNETPaginationSortingHW.Repositories.Interfaces;
using ASPNETPaginationSortingHW.Services.Interfaces;
using ASPNETPaginationSortingHW.ViewModels;
using static ASPNETPaginationSortingHW.ViewModels.AllBooksViewModel;

namespace ASPNETPaginationSortingHW.Services
{
    public class BookService : IBookService
    {
        private readonly IAppData _data;

        public BookService(IAppData data)
        {
            _data = data;
        }

        public async Task<int> Add(Book book)
        {
            return await _data.BookRepository.Add(book);
        }

        public async Task<int> Delete(int id)
        {
            return await _data.BookRepository.Delete(id);
        }

        public async Task<int> Edit(Book book)
        {
            return await _data.BookRepository.Edit(book);
        }

        public async Task<Book> GetById(int id)
        {
            return await _data.BookRepository.Get(id);
        }

        public async Task<AllBooksViewModel> GetAll(int page = 1, int count = 12, OrderByEnum orderBy = OrderByEnum.Id)
        {
            int totalCount = await _data.BookRepository.Count();
            int totalPages = (int)Math.Ceiling((double)totalCount / count);
            if (page > totalPages)
            {
                page = totalPages;
            }
            IEnumerable<Book> books = await _data.BookRepository.Get(page, count, (int)orderBy);
            return new()
            {
                Items = books,
                Count = totalCount,
                CurrentPage = page,
                TotalPages = totalPages,
                OnPage = count,
                OrderBy = orderBy
            };
        }
    }
}
