---
sessionId: session-260912-155516-apri
---

# Requirements

### Overview & Goals
Provide a dedicated unit test class `NullableTests` in the `UnitTests` project for `CSharpLib.Nullable` (`CSharpLib/Nullable.cs`). This ensures coverage for the tutorial methods demonstrating C# nullable value types (`System.Nullable<T>`, `T?`, `HasValue`, `GetValueOrDefault()`, and null-coalescing `??` operations).

### Scope
- **In Scope**:
  - Creation of `UnitTests/NullableTests.cs` matching the xUnit testing conventions in `UnitTests`.
  - Adding test methods to invoke `CSharpLib.Nullable.TestNullable()` with test output helper redirection.
  - Adding focused unit test assertions validating nullable value type mechanics (`HasValue`, `GetValueOrDefault`, `??` operator fallback and value assignment).
- **Out of Scope**:
  - Modifying the tutorial implementation in `CSharpLib/Nullable.cs`.
  - Refactoring global test runner infrastructure or unrelated test fixtures.

### Functional Requirements
- **FR-1**: A new test class `NullableTests` must be added under `UnitTests/NullableTests.cs`.
- **FR-2**: The test class must instantiate `ITestOutputHelper` and redirect standard console output using `UnitTests.Converter`.
- **FR-3**: Must test execution of `CSharpLib.Nullable.TestNullable()` without throwing exceptions.
- **FR-4**: Must provide test cases asserting nullable value type properties (`HasValue` is false when null, true when initialized, `GetValueOrDefault()` returns default or value, null-coalescing `??` produces expected defaults).

# Technical Design

### Current Implementation
- `CSharpLib/Nullable.cs` defines `CSharpLib.Nullable` with a static method `TestNullable()`.
- The method demonstrates `Nullable<int> i = null`, checking `i.HasValue`, `i.GetValueOrDefault()`, `int? x = null`, `double? D = null`, and `x ?? 0`.
- Existing test classes in `UnitTests` (e.g. `DynamicTypesTest.cs`, `EnumTests.cs`, `VariableTests.cs`) use xUnit (`[Fact]`, `Assert.Equal`, `Assert.True`, `Assert.False`), injecting `ITestOutputHelper` in the constructor and wrapping it with `Console.SetOut(new Converter(output))`.

### Key Decisions
- **Namespace Qualification**: Because `System.Nullable` and `CSharpLib.Nullable` share the same class name, tests will explicitly reference `CSharpLib.Nullable.TestNullable()` or use `using CSharpLib;` carefully to avoid compiler ambiguity.
- **Test Structure**: Follow the established xUnit pattern with constructor-injected `ITestOutputHelper` and `Converter` for console capture.

### Proposed Changes
- Add `UnitTests/NullableTests.cs`:
  ```csharp
  using CSharpLib;
  using Xunit.Abstractions;

  namespace UnitTests;

  public class NullableTests
  {
      private readonly ITestOutputHelper _output;

      public NullableTests(ITestOutputHelper output)
      {
          _output = output;
          var converter = new Converter(output);
          Console.SetOut(converter);
      }

      [Fact]
      public void TestNullable_ExecutesSuccessfully()
      {
          CSharpLib.Nullable.TestNullable();
      }

      [Fact]
      public void Nullable_HasValueAndDefaultValue_BehaveAsExpected()
      {
          int? nullInt = null;
          Assert.False(nullInt.HasValue);
          Assert.Equal(0, nullInt.GetValueOrDefault());
          Assert.Equal(42, nullInt.GetValueOrDefault(42));

          int? valuedInt = 10;
          Assert.True(valuedInt.HasValue);
          Assert.Equal(10, valuedInt.Value);
          Assert.Equal(10, valuedInt.GetValueOrDefault());
      }

      [Fact]
      public void Nullable_NullCoalescingOperator_AssignsFallback()
      {
          int? x = null;
          int j = x ?? 0;
          Assert.Equal(0, j);

          int? y = 25;
          int k = y ?? 0;
          Assert.Equal(25, k);
      }
  }
  ```

### File Structure
- Added: `UnitTests/NullableTests.cs`

# Testing

### Validation Approach
- Verify `UnitTests/NullableTests.cs` compiles against .NET 10.0 and xUnit.
- Run targeted tests using `dotnet test --filter FullyQualifiedName~NullableTests` to confirm that all test facts pass without errors.

### Key Scenarios
- **Scenario 1 - Tutorial Execution**: `CSharpLib.Nullable.TestNullable()` executes and outputs expected strings to `ITestOutputHelper`.
- **Scenario 2 - Null State Verification**: Nullable integer with `null` value has `HasValue == false` and returns `0` via `GetValueOrDefault()`.
- **Scenario 3 - Non-Null State Verification**: Nullable integer with assigned value has `HasValue == true` and returns the assigned value.
- **Scenario 4 - Null-Coalescing Fallback**: Expression `x ?? defaultValue` returns default value when `x` is `null` and `x.Value` when assigned.

# Delivery Steps

### ✓ Step 1: Create NullableTests test class with output redirection and execution test
The `NullableTests` test fixture class is created in the `UnitTests` project with xUnit test output redirection and initial invocation test.

- Create `UnitTests/NullableTests.cs` within the `UnitTests` namespace.
- Add constructor accepting `ITestOutputHelper` and configure `Console.SetOut(new Converter(output))` following existing project patterns.
- Add `TestNullable_ExecutesWithoutException` test method to execute `CSharpLib.Nullable.TestNullable()` and verify successful execution.

### ✓ Step 2: Add comprehensive test cases for nullable behaviors and validate test run
The test suite includes dedicated unit test cases verifying nullable semantics demonstrated in `Nullable.cs`, and the tests pass successfully.

- Add unit test cases for nullable assignment, `HasValue`, `Value`, and `GetValueOrDefault()`.
- Add unit test cases for the null-coalescing operator `??` with nullable value types (`int?`, `double?`).
- Run `dotnet test --filter FullyQualifiedName~NullableTests` to validate that all test cases execute and pass cleanly.