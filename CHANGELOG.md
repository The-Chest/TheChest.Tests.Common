# v0.1.0

## What's Added
* Custom Dependency Injection system 
  * `DIContainer` - a simple DI container for managing dependencies
  * `DIRegistry` - a registry for configuring type mappings and lifetimes
  * `DIRegistration` - represents a single type registration in the DI container
* `BaseTest<T>` for reusable test setup and randomization
* Item factories for test data generation 
  * `ItemFactory<T>` - a base class for creating test items
  * `IItemFactory<T>` - an interface for item factories to implement
* Type-driven conditional test attributes (`TypeConditionAttribute`)
  * `IgnoreIfPrimitiveTypeAttribute` - ignores tests if the type is a primitive type
  * `IgnoreIfReferenceTypeAttribute` - ignores tests if the type is a reference type
  * `IgnoreIfValueTypeAttribute` - ignores tests if the type is a value type
* Utility extensions for randomization and type operations

## Known Issues
* Type-driven conditional attributes are not working due to NUnit dependencies

## What's next
* Expand item factory support for more types
* Make type-driven conditional attributes work
