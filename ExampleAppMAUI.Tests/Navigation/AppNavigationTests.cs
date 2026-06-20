using ExampleAppMAUI.Shared.Navigation;
using ExampleAppMAUI.Tests.Testing;

namespace ExampleAppMAUI.Tests.Navigation;

internal static class AppNavigationTests
{
    public static void Run()
    {
        UsesCustomAppIdentity();
        DefinesPrimaryAppRoutes();
    }

    private static void UsesCustomAppIdentity()
    {
        TestAssert.Equal("Akshat Tasks", AppNavigationText.BrandName, "Brand name should use custom app identity.");
    }

    private static void DefinesPrimaryAppRoutes()
    {
        TestAssert.Equal("todos", AppNavigationRoutes.Todos, "Todos route should remain available.");
        TestAssert.Equal("profile", AppNavigationRoutes.Profile, "Profile route should be available.");
        TestAssert.Equal("settings", AppNavigationRoutes.Settings, "Settings route should be available.");
    }
}
