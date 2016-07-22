# TypeScriptBuilder

Small library to generate TypeScript type definition based on C# types.

Install by nuget:
```
Install-Package TypeScriptBuilder
```

## Usage

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

## Supported features
- Generics
- Type inheritance
- Enums
- Dictionary converison (to strong type TS indexed objects)
- Excluding types
- `any` for types that can't be converted
