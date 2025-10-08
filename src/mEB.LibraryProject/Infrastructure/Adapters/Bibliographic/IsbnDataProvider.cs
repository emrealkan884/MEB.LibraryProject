namespace Infrastructure.Adapters.Bibliographic;

public class IsbnDataProvider
{
	public Task<(string title, string author)> FetchAsync(string isbn, CancellationToken ct)
	{
		// TODO: Integrate WorldCat/TO-KAT/Milli Kütüphane; stubbed
		return Task.FromResult((title: $"Stub Title for {isbn}", author: "Stub Author"));
	}
}


