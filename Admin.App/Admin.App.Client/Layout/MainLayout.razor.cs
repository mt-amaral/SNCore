using BootstrapBlazor.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace Admin.App.Client.Layout
{
    public partial class MainLayout
    {

        private List<MenuItem>? _menus { get; set; }
        
        protected override void OnInitialized()
        {
            base.OnInitialized();

            _menus = GetIconSideMenuItems();
        }

        private static List<MenuItem> GetIconSideMenuItems()
        {
            return new List<MenuItem>
            {
                new() { Text = "Dashboard", Icon = "fa-solid fa-fw fa-chart-line", Url = "/" , Match = NavLinkMatch.All},
                new() { Text = "Host", Icon = "fa-solid fa-server", Url = "/Hosts" , Match = NavLinkMatch.All},
            };
            
        }
    }
}
