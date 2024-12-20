using TodoApp.Shared.Responses;

namespace TodoApp.Application.Features.Queries.Tasks;

public class GetTaskByIdQueryResponse
{

}
public class GetTaskByIdQueryRequest : IRequest<IDataResponse<GetTaskByIdQueryResponse>>
{
}
public class GetTaskByIdQueryHandler : IRequestHandler<GetTaskByIdQueryRequest, IDataResponse<GetTaskByIdQueryResponse>>
{
    public Task<IDataResponse<GetTaskByIdQueryResponse>> Handle(GetTaskByIdQueryRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
