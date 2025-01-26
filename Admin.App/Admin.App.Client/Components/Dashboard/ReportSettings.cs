

using Admin.App.Client.Data.Dashborad;

namespace Admin.App.Client.Components.Dashboard;

public class ReportSettings
{
    public string Title { get; set; }
    public string BarColour { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public List<ClaimReportData> ChartData { get; set; }
}
