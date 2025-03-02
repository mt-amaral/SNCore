namespace Admin.Shared.Response;

public class ItemModelResponse
{
    public int? Id { get; set; }
    public string ItemName { get; set; } = string.Empty;
    public long OidId { get; set; }
    public string OidName { get; set; } = string.Empty;

}