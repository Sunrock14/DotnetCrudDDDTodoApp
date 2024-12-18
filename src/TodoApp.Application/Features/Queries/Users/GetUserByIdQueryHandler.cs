using MediatR;
using TodoApp.Shared.Entities;
using TodoApp.Shared.Responses;

namespace TodoApp.Application.Features.Queries.Users;

public class GetUserByIdQueryResponse : BaseDto
{

}

public class GetUserByIdQueryRequest : IRequest<IDataResponse<GetUserByIdQueryResponse>>
{
    public Guid UserId { get; set; }
}

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQueryRequest, IDataResponse<GetUserByIdQueryResponse>>
{
    public async Task<IDataResponse<GetUserByIdQueryResponse>> Handle(GetUserByIdQueryRequest request, CancellationToken cancellationToken)
    {
         var a = request.UserId;
        return new DataResponse<GetUserByIdQueryResponse>(true, "" , new GetUserByIdQueryResponse
        {
            CurrentPage = 1
        });
    }
}
