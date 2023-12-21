using MediatR;
using Mediatr3.Domains;
using Mediatr3.Interface;
using Mediatr3.Queries;

namespace Mediatr3.Handlers;

internal sealed record GetStudentListHandler : IRequestHandler<GetStudentListQuery, List<StudentDetails>>
{
    private readonly IStudentRepository _studentRepository;

    public GetStudentListHandler(IStudentRepository studentRepository) 
        => _studentRepository = studentRepository;

    public async Task<List<StudentDetails>> Handle(GetStudentListQuery request, CancellationToken cancellationToken) 
        => await _studentRepository.GetStudentListAsync();
}