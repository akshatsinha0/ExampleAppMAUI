using ExampleAppMAUI.Shared.Todos;
using ExampleAppMAUI.Shared.AppIdentity;
using ExampleAppMAUI.Shared.Profile;
using ExampleAppMAUI.Shared.Settings;

namespace ExampleAppMAUI.Shared.Navigation;

public static class AppNavigationText
{
    public const string BrandName = AppIdentityText.Name;
    public const string Home = "Home";
    public const string Profile = ProfileText.PageTitle;
    public const string Settings = SettingsText.PageTitle;
    public const string Todos = TodoText.NavigationLabel;
}
