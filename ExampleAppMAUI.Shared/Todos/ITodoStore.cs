namespace ExampleAppMAUI.Shared.Todos;

public interface ITodoStore
{
    Task<IReadOnlyList<TodoItem>> LoadAsync(CancellationToken cancellationToken = default);

    Task SaveAsync(IEnumerable<TodoItem> todos, CancellationToken cancellationToken = default);
}
