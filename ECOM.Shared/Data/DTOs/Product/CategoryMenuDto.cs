namespace ECOM.Shared.Data.DTOs.Product
{
    // header'daki kategori menüsü için üst kategori ve altındaki alt kategoriler
    public class CategoryMenuDto
    {
        public int CategoryId { get; set; }
        public string Name { get; set; } = null!;
        public List<SubCategoryMenuDto> SubCategories { get; set; } = [];
    }

    public class SubCategoryMenuDto
    {
        public int CategoryId { get; set; }
        public string Name { get; set; } = null!;
    }
}
