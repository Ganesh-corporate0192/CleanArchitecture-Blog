namespace CleanArchitecture.Domain.Entities
{
    public class Blog
    {
        public int Id { get;  set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
    }
}