public class UpsertResult
{
    public int Created { get; set; }
    public int Updated { get; set; }

    public List<int> CreatedIds { get; set; } = new();
    public List<int> UpdatedIds { get; set; } = new();
}