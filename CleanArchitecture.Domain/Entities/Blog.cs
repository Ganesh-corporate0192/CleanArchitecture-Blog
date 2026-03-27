namespace CleanArchitecture.Domain.Entities
{
    public class Blog
    {
        public int Id { get; private set; }

        public string Name { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public string Author { get; private set; } = string.Empty;
        public string ImageUrl { get; private set; } = string.Empty;

        // Constructor for creation
        public Blog(string name, string description, string author, string imageUrl)
        {
            Update(name, description, author, imageUrl);
        }

        // EF Core requires parameterless constructor
        private Blog() { }

        // Update method (central logic)
        public void Update(string name, string description, string author, string imageUrl)
        {
            Name = name?.Trim() ?? string.Empty;
            Description = description?.Trim() ?? string.Empty;
            Author = author?.Trim() ?? string.Empty;
            ImageUrl = imageUrl?.Trim() ?? string.Empty;
        }
    }
}