# Copilot Instructions for TheChest.Tests.Common

**Project Language:** English is the primary language for all code, documentation, and comments in this repository.

## Overview
This project provides common test utilities, dependency injection, and item factories for The Chest ecosystem. It is structured as a .NET Standard 2.1 library, focusing on reusable test patterns and extensible DI mechanisms.

## Architecture & Key Components
- **Dependency Injection**: Custom DI system (`DependencyInjection/DIContainer.cs`, `DIRegistry.cs`) for registering and resolving services and factories. Avoid using external DI frameworks.
- **Test Base**: `BaseTest<T>` is the foundation for test classes, providing DI setup and randomization utilities.
- **Item Factories**: `Items/ItemFactory.cs` and `IItemFactory.cs` provide generic creation of test items, including random and default values. Factories are registered in DI by default.
- **Attributes**: Custom attributes (e.g., `IgnoreIfPrimitiveTypeAttribute`) are used for conditional test logic, especially for type-based test exclusion.
- **Extensions**: Utility extensions (e.g., `ArrayExtensions.Shuffle`) are used for randomization and type operations.

## Developer Workflows
- **Build**: Use standard .NET CLI commands:
  - `dotnet build src/TheChest.Tests.Common/TheChest.Tests.Common.csproj`
- **Test**: This project provides test utilities, not tests themselves. Consumers should reference this library in their test projects.
- **Debug**: Debug consumer test projects as usual; this library is designed to be transparent in the debug workflow.

## Project Conventions
- **No Implicit Usings/Nullables**: Explicit usings and nullability are enforced (`.csproj` disables implicit usings and nullable reference types).
- **Type-Driven Patterns**: Many utilities and attributes operate based on type reflection (see `TypeConditionAttribute` and its derivatives).
- **Registration Patterns**: Always register factories and services via the custom DI system, not via external containers.
- **Randomization**: Use provided extensions and DI-injected `Random` instances for all random logic in tests.

## Integration Points
- **Consumers**: Reference this library from other test projects in The Chest ecosystem.
- **No External Dependencies**: The codebase is self-contained and does not rely on third-party packages for DI or test utilities.

## Key Files & Directories
- `src/TheChest.Tests.Common/DependencyInjection/` — Custom DI system
- `src/TheChest.Tests.Common/Items/` — Item factories and test item types
- `src/TheChest.Tests.Common/Attributes/` — Conditional test attributes
- `src/TheChest.Tests.Common/Extensions/` — Utility extensions
- `src/TheChest.Tests.Common/BaseTest.cs` — Abstract base for test classes

## Example Usage
```csharp
public class MyTest : BaseTest<MyType>
{
    public MyTest() : base(cfg => cfg.Register<IMyService, MyService>()) {}
    // ...
}
```

## Additional Notes
- Keep all new utilities generic and reusable.
- Document new patterns in this file for future AI agents.
