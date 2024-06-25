using Dapper.WebUserInterface.Dtos.CategoryDtos;

namespace Dapper.WebUserInterface.Services
{
    public interface ICategoryService
    {
        Task<List<ResultCategoryDto>> GetCategoriesAsync();
        Task<GetCategoryByIdDto> GetCategoryByAsync(int id);
        Task CreateCategoryAsync(CreateCategoryDto createCategoryDto);
        Task DeleteCategoryAsync(int id);
        Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);
    }
}
