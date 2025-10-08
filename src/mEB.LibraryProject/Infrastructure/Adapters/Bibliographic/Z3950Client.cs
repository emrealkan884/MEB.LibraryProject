namespace Infrastructure.Adapters.Bibliographic;

public class Z3950Client
{
	public Task<string> FetchMarcByIsbnAsync(string isbn, CancellationToken ct)
	{
		// TODO: Implement Z39.50; return MARC21 record as raw text/JSON stub
		return Task.FromResult($"MARC-STUB for ISBN {isbn}");
	}
}


