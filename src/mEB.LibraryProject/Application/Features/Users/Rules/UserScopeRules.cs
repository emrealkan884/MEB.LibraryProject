using NArchitecture.Core.Application.Rules;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Application.Features.Users.Rules;

public class UserScopeRules : BaseBusinessRules
{
	private readonly IHttpContextAccessor _httpContextAccessor;
	public UserScopeRules(IHttpContextAccessor httpContextAccessor) { _httpContextAccessor = httpContextAccessor; }

	public Guid? GetCurrentUserKutuphaneId()
	{
		var user = _httpContextAccessor.HttpContext?.User;
		string? val = user?.FindFirst("kutuphaneId")?.Value;
		return Guid.TryParse(val, out var id) ? id : null;
	}
}


