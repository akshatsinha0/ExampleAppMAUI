using System.Text.Json;

namespace ExampleAppMAUI.Shared.Todos;

public sealed class JsonTodoStore : ITodoStore
{
    private static readonly JsonSerializerOptions SerializerOptions = new(JsonSerializerDefaults.Web)
    {
        WriteIndented = true
    };

    private readonly string storagePath;

    private JsonTodoStore(string storagePath)
    {
        this.storagePath = storagePath;
    }

    public static JsonTodoStore CreateForFile(string storagePath)
    {
        return new JsonTodoStore(storagePath);
    }

    public async Task<IReadOnlyList<TodoItem>> LoadAsync(CancellationToken cancellationToken = default)
    {
        if (!File.Exists(storagePath))
        {
            return Array.Empty<TodoItem>();
        }

        await using var stream = File.OpenRead(storagePath);
        var todos = await JsonSerializer.DeserializeAsync<List<TodoItem>>(
            stream,
            SerializerOptions,
            cancellationToken);

        return todos ?? [];
    }

    public async Task SaveAsync(IEnumerable<TodoItem> todos, CancellationToken cancellationToken = default)
    {
        var directory = Path.GetDirectoryName(storagePath);

        if (!string.IsNullOrWhiteSpace(directory))
        {
            Directory.CreateDirectory(directory);
        }

        await using var stream = File.Create(storagePath);
        await JsonSerializer.SerializeAsync(stream, todos.ToArray(), SerializerOptions, cancellationToken);
    }
}
