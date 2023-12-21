using MediatR;
using Mediatr3.Commands;
using Mediatr3.Interface;

namespace Mediatr3.Handlers;

internal sealed record DeleteStudentHandler : IRequestHandler<DeleteStudentCommand, int>
{
    private readonly IStudentRepository _studentRepository;

    public DeleteStudentHandler(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public async Task<int> Handle(DeleteStudentCommand command, CancellationToken cancellationToken)
    {
        var studentDetails = await _studentRepository.GetStudentByIdAsync(command.Id);
        if (studentDetails == null)
            return default;

        return await _studentRepository.DeleteStudentAsync(studentDetails.Id);
    }
}