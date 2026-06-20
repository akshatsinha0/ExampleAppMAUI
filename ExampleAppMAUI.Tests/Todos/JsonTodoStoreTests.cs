using ExampleAppMAUI.Shared.Todos;
using ExampleAppMAUI.Tests.Testing;

namespace ExampleAppMAUI.Tests.Todos;

internal static class JsonTodoStoreTests
{
    public static async Task RunAsync()
    {
        await MissingFileReturnsEmptyListAsync();
        await SaveAndLoadPreservesTodosAsync();
    }

    private static async Task MissingFileReturnsEmptyListAsync()
    {
        var store = JsonTodoStore.CreateForFile(CreateStoragePath());

        var todos = await store.LoadAsync();

        TestAssert.Equal(0, todos.Count, "Missing TODO file should load as empty list.");
    }

    private static async Task SaveAndLoadPreservesTodosAsync()
    {
        var store = JsonTodoStore.CreateForFile(CreateStoragePath());
        var todo = TodoItemActions.ToggleCompletion(TodoItemFactory.Create("Persist item"));

        await store.SaveAsync(new[] { todo });
        var todos = await store.LoadAsync();

        TestAssert.Equal(1, todos.Count, "Saved TODO list should load one item.");
        TestAssert.Equal(todo.Id, todos[0].Id, "Saved TODO identifier should round trip.");
        TestAssert.Equal(todo.Status, todos[0].Status, "Saved TODO status should round trip.");
    }

    private static string CreateStoragePath()
    {
        return Path.Combine(Path.GetTempPath(), "ExampleAppMAUI.Tests", $"{Guid.NewGuid():N}.json");
    }
}
