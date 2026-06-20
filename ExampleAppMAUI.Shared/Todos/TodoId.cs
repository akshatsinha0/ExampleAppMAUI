namespace ExampleAppMAUI.Shared.Todos;

public readonly record struct TodoId(string Value)
{
    public static TodoId NewId()
    {
        return new TodoId(Guid.NewGuid().ToString("N"));
    }
}
