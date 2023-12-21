using MediatR;
using Mediatr3.Domains;
using Mediatr3.Interface;
using Mediatr3.Queries;

namespace Mediatr3.Handlers;

internal sealed record GetStudentByIdHandler : IRequestHandler<GetStudentByIdQuery, StudentDetails>
{
    private readonly IStudentRepository _studentRepository;

    public GetStudentByIdHandler(IStudentRepository studentRepository) 
        => _studentRepository = studentRepository;

    public async Task<StudentDetails> Handle(GetStudentByIdQuery query, CancellationToken cancellationToken) 
        => await _studentRepository.GetStudentByIdAsync(query.Id);
}