## TheChest.Tests.Common

The **TheChest.Tests.Common** library provides a collection of reusable test utilities, custom dependency injection, item factories and conditional attributes used across "The Chest" ecosystem. 
It's designed to be referenced by consumer test projects, not run standalone.

### Project Overview

- **Language**: C# targeting .NET Standard 2.1
- **Purpose**: Supply common infrastructure for writing deterministic, randomized, and type-driven unit tests without relying on third-party DI frameworks.
- **Usage**: Add a project or package reference from your test project; then extend
  `BaseTest<T>` or register factories/services in the built-in DI container.

### Example Usage

```csharp
public class MyTypeTests : BaseTest<MyType>
{
    public MyTypeTests() : base(cfg => cfg.Register<IMyService, MyService>())
    {
        // additional setup if needed
    }

    [Fact]
    public void CanCreateRandomItem()
    {
        var item = GetService<IItemFactory<MyType>>().CreateRandom();
        Assert.NotNull(item);
    }
}
```

## Future Plans

The plans for future versions are in this [GitHub Project Board](https://github.com/orgs/The-Chest/projects/30/views/1), with insights into upcoming features, improvements, and release timelines.
