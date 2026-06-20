namespace ExampleAppMAUI.Shared.Todos;

public sealed record TodoItem(
    TodoId Id,
    string Title,
    TodoCompletionStatus Status,
    DateTimeOffset CreatedAt,
    DateTimeOffset? CompletedAt);
