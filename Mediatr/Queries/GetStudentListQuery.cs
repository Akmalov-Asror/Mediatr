using MediatR;
using Mediatr3.Domains;
namespace Mediatr3.Queries;

public record GetStudentListQuery : IRequest<List<StudentDetails>>
{
}