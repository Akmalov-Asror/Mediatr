using MediatR;
using Mediatr3.Commands;
using Mediatr3.Domains;
using Mediatr3.Interface;

namespace Mediatr3.Handlers;

internal sealed record CreateStudentHandler : IRequestHandler<CreateStudentCommand, StudentDetails>
{
    private readonly IStudentRepository _studentRepository;

    public CreateStudentHandler(IStudentRepository studentRepository) 
        => _studentRepository = studentRepository;

    public async Task<StudentDetails> Handle(CreateStudentCommand command, CancellationToken cancellationToken)
    {
        var studentDetails = new StudentDetails()
        {
            StudentName = command.StudentName,
            StudentEmail = command.StudentEmail,
            StudentAddress = command.StudentAddress,
            StudentAge = command.StudentAge
        };
        return await _studentRepository.AddStudentAsync(studentDetails);
    }
}