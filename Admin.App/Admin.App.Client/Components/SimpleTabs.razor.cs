using Microsoft.AspNetCore.Components;

namespace Admin.App.Client.Components;

public partial class SimpleTabs
{
    [Parameter]
    public RenderFragment ChildContent { get; set; }

    [Parameter]
    public TabItem ActiveTab { get; set; }

    [Parameter]
    public EventCallback<TabItem> ActiveTabChanged { get; set; }

    public List<TabItem> ChildTabs { get; } = new List<TabItem>();

    protected override void OnAfterRender(bool firstRender)
    {
        if (firstRender && ChildTabs.Any() && ActiveTab == null)
        {
            ActiveTab = ChildTabs.First();
            StateHasChanged();
        }
    }

    private void ActivateTab(TabItem tab)
    {
        ActiveTab = tab;
        ActiveTabChanged.InvokeAsync(tab);
        StateHasChanged();
    }

    public string GetTabClass(TabItem tab)
    {
        return ActiveTab == tab ? "tab-button active" : "tab-button";
    }
}
