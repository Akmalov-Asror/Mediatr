using MediatR;
using Mediatr3.Commands;
using Mediatr3.Interface;

namespace Mediatr3.Handlers;

internal sealed record UpdateStudentHandler : IRequestHandler<UpdateStudentCommand, int>
{
    private readonly IStudentRepository _studentRepository;

    public UpdateStudentHandler(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }
    public async Task<int> Handle(UpdateStudentCommand command, CancellationToken cancellationToken)
    {
        var studentDetails = await _studentRepository.GetStudentByIdAsync(command.Id);

        studentDetails.StudentName = command.StudentName;
        studentDetails.StudentEmail = command.StudentEmail;
        studentDetails.StudentAddress = command.StudentAddress;
        studentDetails.StudentAge = command.StudentAge;

        return await _studentRepository.UpdateStudentAsync(studentDetails);
    }
}