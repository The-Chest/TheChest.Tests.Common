# v0.2.0

## What's Added
* Extension methods for reflection-based test utilities
  * `ContainerExtensions`
    * `GetTypeIfImplements(Type interfaceType)`
      * Checks whether a type implements the specified interface and returns the validated type.
    * `GetSlotsField()`
      * Retrieves the internal `slots` field from container implementations.
  * `SlotExtensions`
    * `GetSlotTypeByConstructor<TSlotInterface>(string slotParameterName = "slots")`
      * Retrieves the slot type used by a container constructor.
    * `GetContentField()`
      * Retrieves the internal `content` field from slot implementations.
    * `GetContentFieldValue<T>()`
      * Retrieves the value stored in a slot.
    * `GetContentFieldValues<T>()`
      * Retrieves the values stored in stack-based slot implementations.

## What's Changed
* Project structure reorganization
  * Moved attributes, extensions, item types, configuration classes, and test base classes to a simplified folder structure.
  * Renamed dependency injection namespaces to `TheChest.Tests.Common.Configurations.DependencyInjection`.
* Dependency Injection
  * `DIRegistration`
    * Changed visibility from `public` to `internal`.
  * `DIRegistry`
    * Changed visibility from `public` to `internal`.
* Test items
  * Renamed namespaces from singular to plural forms.
    * `Items.ReferenceType` → `Items.ReferenceTypes`
    * `Items.ValueType` → `Items.ValueTypes`
* Project configuration
  * Updated package documentation paths for `README.md` and `CHANGELOG.md`.

## What's Removed
* Removed dependency on `TheChest.Core` package.
* Removed interface-specific reflection extensions.
  * `IContainerExtensions`
    * Replaced by container-agnostic extension methods.
  * `ISlotExtensions`
    * Replaced by slot-agnostic extension methods.

## What's Fixed
* Dependency Injection
  * Improved internal implementation consistency by removing unnecessary `this` qualifiers.
  * Simplified internal resolution and registration calls.
  * Simplified factory detection condition checks.

## Known Issues
* Reflection-based extensions still depend on internal field names such as `slots` and `content`.

**Full Changelog**: https://github.com/The-Chest/TheChest.Templates/compare/v0.1.0...v0.2.0

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
