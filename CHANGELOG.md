# v0.1.0

## What's Added
* Custom Dependency Injection system 
  * `DIContainer`
  * `DIRegistry`
  * `DIRegistration`
* `BaseTest<T>` for reusable test setup and randomization
* Item factories for test data generation 
  * ItemFactory
  * IItemFactory
* Type-driven conditional test attributes (`TypeConditionAttribute`)
  * `IgnoreIfPrimitiveTypeAttribute`
  * `IgnoreIfReferenceTypeAttribute`
  * `IgnoreIfValueTypeAttribute`
* Utility extensions for randomization and type operations

## Known Issues
* Type-driven conditional attributes are not working due NUnit dependencies

## What's next
* Expand item factory support for more types
* Add more conditional test attributes
* Improve DI container features
* Enhance documentation and examples
