using Dapper.WebUserInterface.Context;
using Dapper.WebUserInterface.Dtos.ProductDtos;

namespace Dapper.WebUserInterface.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly DapperOrmProjectContext _context;

        public ProductService(DapperOrmProjectContext context)
        {
            _context = context;
        }

        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            string query = @"
            INSERT INTO Products 
                   (ProductName, SupplierID, CategoryID, QuantityPerUnit, UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued) 
            VALUES 
                   (@ProductName, @SupplierID, @CategoryID, @QuantityPerUnit, @UnitPrice, @UnitsInStock, @UnitsOnOrder, @ReorderLevel, @Discontinued)";

            var parameters = new DynamicParameters();
            parameters.Add("@ProductName", createProductDto.ProductName);
            parameters.Add("@SupplierID", createProductDto.SupplierID);
            parameters.Add("@CategoryID", createProductDto.CategoryID);
            parameters.Add("@QuantityPerUnit", createProductDto.QuantityPerUnit);
            parameters.Add("@UnitPrice", createProductDto.UnitPrice);
            parameters.Add("@UnitsInStock", createProductDto.UnitsInStock);
            parameters.Add("@UnitsOnOrder", createProductDto.UnitsOnOrder);
            parameters.Add("@ReorderLevel", createProductDto.ReorderLevel);
            parameters.Add("@Discontinued", createProductDto.Discontinued);
            var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public Task DeleteProductAsync(int id)
        {
            string query = "DELETE FROM Products WHERE ProductID = @ProductID";
            var parameters = new DynamicParameters();
            parameters.Add("@ProductID", id);
            var connection = _context.CreateConnection();
            return connection.ExecuteAsync(query, parameters);
        }

        public async Task<GetProductByIdDto> GetProductByAsync(int id)
        {
            string query = "SELECT * FROM Products WHERE ProductID = @ProductID";
            var parameters = new DynamicParameters();
            parameters.Add("@ProductID", id);
            var connection = _context.CreateConnection();
            var values = await connection.QueryFirstOrDefaultAsync<GetProductByIdDto>(query, parameters);
            return values;
        }

        public async Task<List<ResultProductDto>> GetProductsAsync()
        {
            string query = "SELECT * FROM Products";
            var connection = _context.CreateConnection();
            var values = await connection.QueryAsync<ResultProductDto>(query);
            return values.ToList();
        }

        public Task<List<ResultProductsWithCategoriesDto>> GetProductsWithCategoriesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            string query = @"
            UPDATE Products 
            SET ProductName = @ProductName, 
                SupplierID = @SupplierID, 
                CategoryID = @CategoryID, 
                QuantityPerUnit = @QuantityPerUnit, 
                UnitPrice = @UnitPrice, 
                UnitsInStock = @UnitsInStock, 
                UnitsOnOrder = @UnitsOnOrder, 
                ReorderLevel = @ReorderLevel, 
                Discontinued = @Discontinued 
            WHERE ProductID = @ProductID";

            var paramaters = new DynamicParameters();
            paramaters.Add("ProductName", updateProductDto.ProductName);
            paramaters.Add("SupplierID", updateProductDto.SupplierID);
            paramaters.Add("CategoryID", updateProductDto.CategoryID);
            paramaters.Add("QuantityPerUnit", updateProductDto.QuantityPerUnit);
            paramaters.Add("UnitPrice", updateProductDto.UnitPrice);
            paramaters.Add("UnitsInStock", updateProductDto.UnitsInStock);
            paramaters.Add("UnitsOnOrder", updateProductDto.UnitsOnOrder);
            paramaters.Add("ReorderLevel", updateProductDto.ReorderLevel);
            paramaters.Add("Discontinued", updateProductDto.Discontinued);
            paramaters.Add("ProductID", updateProductDto.ProductID);
            var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, paramaters);
        }
    }
}
