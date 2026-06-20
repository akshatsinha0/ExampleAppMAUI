namespace ExampleAppMAUI.Tests.Testing;

internal static class TestAssert
{
    public static void Equal<T>(T expected, T actual, string message)
    {
        if (!EqualityComparer<T>.Default.Equals(expected, actual))
        {
            throw new InvalidOperationException($"{message} Expected: {expected}. Actual: {actual}.");
        }
    }

    public static void True(bool value, string message)
    {
        if (!value)
        {
            throw new InvalidOperationException(message);
        }
    }
}
