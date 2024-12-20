using AutoMapper;
using TodoApp.Shared.Responses;

namespace TodoApp.Application.Features.Commands.Tasks;

public class CreateTaskCommandResponse
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; } = string.Empty;
}

public class CreateTaskCommandRequest : IRequest<IDataResponse<CreateTaskCommandResponse>>
{
    public string Name { get; set; }
    public string Body { get; set; }
    public string Title { get; set; }
    public string UserId { get; set; }
    public User AssignId { get; set; }
}

public class CreateTaskCommandHandler(IMapper _mapper, IUnitOfWork _unitOfWork) 
    : IRequestHandler<CreateTaskCommandRequest, IDataResponse<CreateTaskCommandResponse>>
{
    public async Task<IDataResponse<CreateTaskCommandResponse>> Handle(CreateTaskCommandRequest request, CancellationToken cancellationToken)
    {
        //Diğer endpointlerde de yap böyle bişiler 
        var mappedTask = _mapper.Map<TodoTask>(request);
        await _unitOfWork.Tasks.AddAsync(mappedTask);
        return new DataResponse<CreateTaskCommandResponse>(true, "OK", new CreateTaskCommandResponse()
        {
            IsSuccess = true,
            Message = ""
        });
    }
}
