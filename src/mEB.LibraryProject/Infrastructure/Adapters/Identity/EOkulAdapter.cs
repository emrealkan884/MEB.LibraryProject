namespace Infrastructure.Adapters.Identity;

public class EOkulAdapter
{
	public Task<(bool success, string userId, string[] roles, Guid? kutuphaneId)> ValidateAsync(string token, CancellationToken ct)
	{
		// TODO: Integrate real E-Okul SSO. Stub returns school librarian.
		return Task.FromResult((true, "eokul-user", new[] { "users.okulyoneticisi" }, (Guid?)Guid.Empty));
	}
}


