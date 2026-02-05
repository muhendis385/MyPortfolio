namespace MyPortfolio.Data
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public int? CategoryId { get; set; }
        public virtual Category? Category { get; set; }

    }
}
