namespace Application.Features.Oduncler.Constants;

public static class OdunclerOperationClaims
{
    private const string _section = "Oduncs";

    public const string Admin = $"{_section}.Admin";

    public const string Read = $"{_section}.Read";
    public const string Write = $"{_section}.Write";

    public const string Create = $"{_section}.Create";
    public const string Update = $"{_section}.Update";
    public const string Delete = $"{_section}.Delete";
}