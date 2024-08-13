using Admin.Share.Enums;

namespace Admin.Share.Request
{
    public class HardwareRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Model HardwareModel { get; set; }
        public string Ipv4 { get; set; }
    }
}
