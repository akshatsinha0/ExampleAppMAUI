namespace ExampleAppMAUI.Shared.Todos;

public static class TodoItemActions
{
    public static TodoItem ToggleCompletion(TodoItem todo)
    {
        return todo.Status == TodoCompletionStatus.Completed
            ? todo with { Status = TodoCompletionStatus.Open, CompletedAt = null }
            : todo with { Status = TodoCompletionStatus.Completed, CompletedAt = DateTimeOffset.UtcNow };
    }
}
