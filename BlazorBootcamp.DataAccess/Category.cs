using System.ComponentModel.DataAnnotations;

namespace BlazorBootcamp.DataAccess
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
    }
}
