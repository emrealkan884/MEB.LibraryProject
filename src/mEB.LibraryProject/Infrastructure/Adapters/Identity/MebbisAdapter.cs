namespace Infrastructure.Adapters.Identity;

public class MebbisAdapter
{
	public Task<(bool success, string userId, string[] roles, Guid? kutuphaneId)> ValidateAsync(string token, CancellationToken ct)
	{
		// TODO: Integrate real MEBBIS SSO. Stub returns admin.
		return Task.FromResult((true, "mebbis-user", new[] { "users.admin" }, (Guid?)null));
	}
}


