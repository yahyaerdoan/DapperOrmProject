using Dapper.WebUserInterface.Context;
using Dapper.WebUserInterface.Dtos.CategoryDtos;

namespace Dapper.WebUserInterface.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly DapperOrmProjectContext _context;

        public CategoryService(DapperOrmProjectContext context)
        {
            _context = context;
        }

        public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            string query = "INSERT INTO Categories (CategoryName, Description) VALUES (@CategoryName, @Description)";
            var parameters = new DynamicParameters();
            parameters.Add("@CategoryName", createCategoryDto.CategoryName);
            parameters.Add("@Description", createCategoryDto.Description);
            var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task DeleteCategoryAsync(int id)
        {
            string query = "DELETE FROM Categories WHERE CategoryID = @CategoryID";
            var parameters = new DynamicParameters();
            parameters.Add("categoryID", id);
            var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task<List<ResultCategoryDto>> GetCategoriesAsync()
        {
            string query = "SELECT * FROM Categories";
            var connection = _context.CreateConnection();
            var values = await connection.QueryAsync<ResultCategoryDto>(query);
            return values.ToList();
        }

        public async Task<GetCategoryByIdDto> GetCategoryByAsync(int id)
        {
            string query = " SELECT * FROM Categories WHERE CategoryID = @CategoryID";
            var parameters = new DynamicParameters();
            parameters.Add("@CategoryID", id);
            var connection = _context.CreateConnection();
            var values = await connection.QueryFirstOrDefaultAsync<GetCategoryByIdDto>(query, parameters);
            return values;
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            string query = "UPDATE Categories SET CategoryName = @CategoryName, Description = @Description WHERE CategoryID = @CategoryID";
            var parameters = new DynamicParameters();
            parameters.Add("CategoryName", updateCategoryDto.CategoryName);
            parameters.Add("Description", updateCategoryDto.Description);
            parameters.Add("CategoryID", updateCategoryDto.CategoryID);
            var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }
    }
}
