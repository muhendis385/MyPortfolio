
namespace MyPortfolio.Data
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public virtual ICollection<Project> Projects { get; set; } = new List<Project>();


    }
}
