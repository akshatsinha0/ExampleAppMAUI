using ExampleAppMAUI.Shared.Todos;
using ExampleAppMAUI.Tests.Testing;

namespace ExampleAppMAUI.Tests.Todos;

internal static class TodoItemTests
{
    public static void Run()
    {
        CreateTodoTrimsTitleAndStartsOpen();
        ToggleTodoChangesCompletionState();
    }

    private static void CreateTodoTrimsTitleAndStartsOpen()
    {
        var todo = TodoItemFactory.Create("  Write tests  ");

        TestAssert.Equal("Write tests", todo.Title, "TODO title should be trimmed.");
        TestAssert.Equal(TodoCompletionStatus.Open, todo.Status, "TODO should start open.");
        TestAssert.True(todo.Id.Value.Length > 0, "TODO should receive an identifier.");
    }

    private static void ToggleTodoChangesCompletionState()
    {
        var todo = TodoItemFactory.Create("Ship feature");
        var completed = TodoItemActions.ToggleCompletion(todo);
        var reopened = TodoItemActions.ToggleCompletion(completed);

        TestAssert.Equal(TodoCompletionStatus.Completed, completed.Status, "Toggle should complete open TODO.");
        TestAssert.Equal(TodoCompletionStatus.Open, reopened.Status, "Toggle should reopen completed TODO.");
    }
}
