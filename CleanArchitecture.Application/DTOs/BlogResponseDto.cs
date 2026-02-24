namespace CleanArchitecture.Application.DTOs
{
    public class BlogResponseDto
    {
        public int Id { get; set; }   // We return Id here
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
    }
}