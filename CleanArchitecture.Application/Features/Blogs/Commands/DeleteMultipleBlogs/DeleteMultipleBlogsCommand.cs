using MediatR;

public record DeleteMultipleBlogsCommand(List<int> Ids) : IRequest<int>;