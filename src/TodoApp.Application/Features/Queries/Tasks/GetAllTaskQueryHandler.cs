using MediatR;
using TodoApp.Shared.Entities;
using TodoApp.Shared.Responses;

namespace TodoApp.Application.Features.Queries.Tasks;

public class GetAllQueryResponse : PaginatedDto
{
}
public class GetallTaskQueryRequest : IRequest<IDataResponse<GetAllQueryResponse>>
{
}
public class GetAllTaskQueryHandler : IRequestHandler<GetallTaskQueryRequest, IDataResponse<GetAllQueryResponse>>
{
    public async Task<IDataResponse<GetAllQueryResponse>> Handle(GetallTaskQueryRequest request, CancellationToken cancellationToken)
    {
        return new DataResponse<GetAllQueryResponse>(true, "", new GetAllQueryResponse
        {

        });
    }
}
