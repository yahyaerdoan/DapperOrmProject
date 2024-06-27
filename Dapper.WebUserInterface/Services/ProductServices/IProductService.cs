using Dapper.WebUserInterface.Dtos.ProductDtos;

namespace Dapper.WebUserInterface.Services.ProductServices
{
    public interface IProductService
    {
        Task<List<ResultProductDto>> GetProductsAsync();
        Task<GetProductByIdDto> GetProductByAsync(int id);
        Task CreateProductAsync(CreateProductDto createProductDto);
        Task DeleteProductAsync(int id);
        Task UpdateProductAsync(UpdateProductDto updateProductDto);
    }
}
