﻿namespace Dapper.WebUserInterface.Dtos.CategoryDtos
{
    public class ResultCategoryDto
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public byte[] Picture { get; set; }
    }
}
