# TypeScriptBuilder

This small library generates TypeScript type definition based on C# types.
Use it directly in your backend C# project to generate code for your frontend TypeScript project.
You can also wrtie small console app, to generate code by pre-build tools.

<b>Works on Full & NET Core framework!</b>

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

// get generated code as string
ts.ToString();

// or write to file
ts.Store("Test.ts");
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
export interface IUser
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
export interface IEntity<T> {
    Value: T;
}
export interface ITest {
    Repo: { [index: number]: IEntity<Date> };
}

```
## Control attributes

You can annotate code with below attributes to affect TS code generation.

### TSExclude
Can be applied on classes, stucts or fields/properties - these items will be omited during TS code generation.
Note: You can also exclude types by using method `ExcludeType`.

### TSAny
When applied on field/property it's type will be set to `any` and skips fruther type analizes.

### TSMap(name)
Can be used on class, struct or enum to rename generated type:
```cs
[TSMap("Funky")]
class MyCSharpClass
{
}
class Test 
{
    public MyCSharpClass Instance;
}
```
```ts
export interface Funky {
}
export interface Test {
    Instance: Funky;
}
```

### TSFlat
If applied on class (B), all fields from base classe (A) are included in class (B):
```cs
class A
{
    public int Id;
    public bool Active;
}
[TSFlat]
class B : A
{
    public string Name;
}
```
```ts
export interface B {
    Id: number;         // from A
    Active: boolean;    // from A
    Name: string;
}
```

## API usage

`TypeScriptGenerator` exposes following methods:
- `TypeScriptGenerator AddCSType(Type type)`: add C# type to generate (dependency types will be added automatically)
- `string TypeName(Type type)`: get TypeScript type name, if requested type requires declaration, it will be automatically added
- `string ToString()`: gets string with generated type declarations (all namespaces combined)
- `void Store(string file)`: stores declarations in to the file
- `TypeScriptGenerator ExcludeType(Type type)`: exclude type

Simply use above methods according to your needs, then use `ToString` to get generated type declarations.

You can also use `CodeTextBuilder` helper class that is used to build nicely formatted code.

### Options

You can pass options `TypeScriptGenerator` constructor:

- `UseCamelCase`: changes field names form `MyTestField` to `myTestField` (default true)
- `EmitIinInterface`: adds I in interface names, `MySimpleData` becomes `IMySimpleData` (default true)
- `EmitReadonly`: adds `readonly` to readonly fields, requires TypeScript 2.0 (default true)
- `EmitComments`: adds comments with oryginal C# type description (default false)

To learn more run `Test` project in the solution.
