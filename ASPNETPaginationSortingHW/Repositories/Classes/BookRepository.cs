using ASPNETPaginationSortingHW.Models;
using ASPNETPaginationSortingHW.Repositories.Interfaces;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using static ASPNETPaginationSortingHW.ViewModels.AllBooksViewModel;

namespace ASPNETPaginationSortingHW.Repositories.Classes
{
    public class BookRepository : IRepository<Book>
    {
        private readonly SqlConnection _connection;

        public BookRepository()
        {
            _connection = DbContext.GetConnection();
        }

        public async Task<int> Add(Book entity)
        {
            string sql = "INSERT INTO Books (Title, Description, Price, Pages) VALUES (@Title, @Description, @Price, @Pages)";
            DynamicParameters dynamicParameters = new();
            dynamicParameters.Add("@Title", entity.Title);
            dynamicParameters.Add("@Description", entity.Description);
            dynamicParameters.Add("@Price", entity.Price);
            dynamicParameters.Add("@Pages", entity.Pages);
            using IDbConnection db = _connection;
            return await db.ExecuteScalarAsync<int>(sql, dynamicParameters);
        }

        public async Task<int> Delete(int id)
        {
            string sql = "DELETE FROM Books WHERE Id = @Id";
            DynamicParameters dynamicParameters = new();
            dynamicParameters.Add("@Id", id);
            using IDbConnection db = _connection;
            await db.ExecuteAsync(sql, dynamicParameters);
            return id;
        }

        public async Task<Book> Get(int id)
        {
            string sql = "SELECT * FROM Books WHERE Id = @Id";
            DynamicParameters dynamicParameters = new();
            dynamicParameters.Add("@Id", id);
            using IDbConnection db = _connection;
            Book book = await db.QueryFirstOrDefaultAsync<Book>(sql, dynamicParameters);
            return book;
        }

        public async Task<int> Edit(Book entity)
        {
            string sql = "UPDATE Books SET Title = @Title, Description = @Description, Price = @Price, Pages = @Pages WHERE Id = @Id";
            DynamicParameters dynamicParameters = new();
            dynamicParameters.Add("@Title", entity.Title);
            dynamicParameters.Add("@Description", entity.Description);
            dynamicParameters.Add("@Price", entity.Price);
            dynamicParameters.Add("@Pages", entity.Pages);
            dynamicParameters.Add("@Id", entity.Id);
            using IDbConnection db = _connection;
            await db.ExecuteAsync(sql, dynamicParameters);
            return entity.Id;
        }

        public async Task<int> Count()
        {
            string sql = "SELECT COUNT(*) FROM Books";
            using IDbConnection db = _connection;
            return await db.ExecuteScalarAsync<int>(sql);
        }

        public async Task<IEnumerable<Book>> Get(int page = 1, int count = 12, int orderBy = (int)OrderByEnum.Id)
        {
            DynamicParameters dynamicParameters = new();
            string orderByString;
            switch ((OrderByEnum)orderBy)
            {
                case OrderByEnum.Id:
                case OrderByEnum.IdDesc:
                    orderByString = "Id";
                    break;
                case OrderByEnum.Title:
                case OrderByEnum.TitleDesc:
                    orderByString = "Title";
                    break;
                case OrderByEnum.Price:
                case OrderByEnum.PriceDesc:
                    orderByString = "Price";
                    break;
                case OrderByEnum.Pages:
                case OrderByEnum.PagesDesc:
                    orderByString = "Pages";
                    break;
                default:
                    orderByString = "Id";
                    break;
            }
            string sql = $@"SELECT * FROM Books ORDER BY {orderByString} {(orderBy % 2 == 0 ? "ASC" : "DESC")} OFFSET @offset ROWS FETCH NEXT @count ROWS ONLY";
            dynamicParameters.Add("@offset", (page - 1) * count);
            dynamicParameters.Add("@count", count);
            using IDbConnection db = _connection;
            return await db.QueryAsync<Book>(sql, dynamicParameters);
        }
    }
}
