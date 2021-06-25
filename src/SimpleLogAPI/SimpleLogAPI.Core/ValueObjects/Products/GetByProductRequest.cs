namespace SimpleLogAPI.Core.ValueObjects.Products
{
    public class GetByProductRequest
    {
        public int? ProductCategoryId { get; set; }
        public virtual string Name { get; set; }
    }
}
