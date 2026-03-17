namespace CleanArchitecture.Domain.Entities
{
    public class Blog
    {
        public int Id { get; set; }

        private string _name = string.Empty;
        public string Name
        {
            get => _name;
            set => _name = value?.Trim() ?? string.Empty;
        }

        private string _description = string.Empty;
        public string Description
        {
            get => _description;
            set => _description = value?.Trim() ?? string.Empty;
        }

        private string _author = string.Empty;
        public string Author
        {
            get => _author;
            set => _author = value?.Trim() ?? string.Empty;
        }

        private string _imageUrl = string.Empty;
        public string ImageUrl
        {
            get => _imageUrl;
            set => _imageUrl = value?.Trim() ?? string.Empty;
        }
    }
}