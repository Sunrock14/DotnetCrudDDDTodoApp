using TodoApp.Shared.Responses;

namespace TodoApp.Application.Features.Queries.Auth;

public class LoginQueryResponse
{
    public string Token { get; set; } = default!;
}
public class LoginQueryRequest : IRequest<IDataResponse<LoginQueryResponse>>
{
    public string UserName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
public class LoginQueryHandler : IRequestHandler<LoginQueryRequest, IDataResponse<LoginQueryResponse>>
{
    public async Task<IDataResponse<LoginQueryResponse>> Handle(LoginQueryRequest request, CancellationToken cancellationToken)
    {
        return new DataResponse<LoginQueryResponse>(true, "", new LoginQueryResponse { });
    }
}
