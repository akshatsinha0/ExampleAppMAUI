namespace ExampleAppMAUI.Shared.Todos;

public static class TodoItemFactory
{
    public static TodoItem Create(string title)
    {
        return new TodoItem(
            TodoId.NewId(),
            title.Trim(),
            TodoCompletionStatus.Open,
            DateTimeOffset.UtcNow,
            null);
    }
}
