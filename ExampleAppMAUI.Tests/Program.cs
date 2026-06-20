using ExampleAppMAUI.Tests.Todos;
using ExampleAppMAUI.Tests.Navigation;

TodoItemTests.Run();
await JsonTodoStoreTests.RunAsync();
AppNavigationTests.Run();

Console.WriteLine("All tests passed.");
