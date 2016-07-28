# TypeScriptBuilder

This small library generates TypeScript type definition based on C# types.
Use it directly in your backend C# project to generate code for your frontend TypeScript project.
You can also wrtie small console app, to generate code by pre-build tools.

<b>It works on NET Core framework!</b>

Install by nuget:
```
Install-Package TypeScriptBuilder
```

## Supported features
- Resolving type dependency
- Generics
- Type inheritance
- Namespaces (modules)
- Enums
- Nullable types
- Dictionary converison (to strong type TS indexed objects)
- Excluding types
- `any` for types that can't be converted

## Usage / Samples
```cs
var
    ts = new TypeScriptGenerator();
    
// add types you need (dependant types will be added automatically)
ts.AddCSType(typeof(User));

// write to file
File.WriteAllText("Test.ts", ts.ToString());
```
Sample C# class:
```cs
class User 
{
  public int Id;
  public string Login;
  
  [TSExclude] // exclude field, can be applied on class too
  public bool Active;
}
```
Output TypeScript:
```ts
export interface User
{
  Id: number;
  Login: string;
}
```

## Dictionary

Dictionaries with keys of type `int` or `string` will be translated to strong typed TS indexed objects:
```cs
class Entity<T>
{
    public T Value;
}
class Test 
{
    public Dictionary<int, Entity<DateTime>> Repo;
}
```
```ts
export interface Entity<T> {
    Value: T;
}
export interface Test {
    Repo: { [index: number]: Entity<Date> };
}

```
## Control attributes
- `TSExclude` - skips generation of type or field
- `TSAny` - skips type analysis, emits `any` instead

You can also exclude types without attributes, use method `ExcludeType`.

## API usage

`TypeScriptGenerator` exposes following methods:
- `TypeScriptGenerator AddCSType(Type type)` - add C# type to generate (dependency types will be added automatically)
- `string TypeName(Type type)` - get TypeScript type name, if requested type requires declaration, it will be automatically added
- `string ToString()` - gets string with generated type declarations
- `TypeScriptGenerator ExcludeType(Type type)` - exclude type

Simply use above methods according to your needs, then use `ToString` to get generated type declarations.

You can also use `CodeTextBuilder` helper class that is used to build nicely formatted code.

### Options

You can pass options `TypeScriptGenerator` constructor:

- `UseCamelCase`: changes field names form `MyTestField` to `myTestField` (default true)
- `EmitIinInterface`: adds I in interface names, `MySimpleData` becomes `IMySimpleData` (default true)
- `EmitReadonly`: adds `readonly` to readonly fields, requires TypeScript 2.0 (default true)

To learn more run `Test` project in the solution.
