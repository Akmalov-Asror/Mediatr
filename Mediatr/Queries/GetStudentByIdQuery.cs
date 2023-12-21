using MediatR;
using Mediatr3.Domains;

namespace Mediatr3.Queries;

public record GetStudentByIdQuery : IRequest<StudentDetails>
{
    public int Id { get; set; }
}