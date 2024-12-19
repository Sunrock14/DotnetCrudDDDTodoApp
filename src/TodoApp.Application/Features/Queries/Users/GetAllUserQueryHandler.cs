using MediatR;
using TodoApp.Shared.Entities;
using TodoApp.Shared.Responses;

namespace TodoApp.Application.Features.Queries.Users;

public class GetAllUserQueryResponse : PaginatedDto
{
    //Dto alanı
    public string Title { get; set; } = default!;
}

public class GetAllUserQueryRequest : IRequest<IDataResponse<GetAllUserQueryResponse>>
{

}

public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQueryRequest, IDataResponse<GetAllUserQueryResponse>>
{
    public async Task<IDataResponse<GetAllUserQueryResponse>> Handle(GetAllUserQueryRequest request, CancellationToken cancellationToken)
    {
         //Get some data 
        return new DataResponse<GetAllUserQueryResponse>(true, "", new GetAllUserQueryResponse
        {
            Title = "",
            CurrentPage = 1
        });
    }
}
