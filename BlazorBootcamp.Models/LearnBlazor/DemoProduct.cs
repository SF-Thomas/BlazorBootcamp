namespace BlazorBootcamp.Models.LearnBlazor
{
    public class DemoProduct
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; }
        public bool IsActive { get; set; }
        public List<DemoProductProperty> ProductProperties { get; set; } = new List<DemoProductProperty>();
    }
}
