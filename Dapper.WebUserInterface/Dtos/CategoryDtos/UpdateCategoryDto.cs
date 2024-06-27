namespace Dapper.WebUserInterface.Dtos.CategoryDtos
{
    public class UpdateCategoryDto
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public byte[] Picture { get; set; }
    }
}
