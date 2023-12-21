using MediatR;

namespace Mediatr3.Commands;

public record DeleteStudentCommand : IRequest<int>
{
    public int Id { get; set; }
}