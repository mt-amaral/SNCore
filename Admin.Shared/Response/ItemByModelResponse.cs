

using Admin.Shared.Payload;

namespace Admin.Shared.Response;

public class ItemByModelResponse : ItemsByModelPayload
{
    public int Id { get; set; }
}
