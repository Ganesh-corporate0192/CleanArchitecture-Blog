namespace CleanArchitecture.Infrastructure.QueryHelpers
{
    public static class SqlQueryLoader
    {
        public static string Load(string relativePath)
        {
            var fullPath = Path.Combine(
                AppContext.BaseDirectory,
                "SQLQueries",
                relativePath);

            return File.ReadAllText(fullPath);
        }
    }
}