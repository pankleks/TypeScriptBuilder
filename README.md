# TypeScriptBuilder

Small library to generate TypeScript type definition based on C# types.

Install by nuget:
```
Install-Package TypeScriptBuilder
```

## Usage

```cs
class User 
{
  public int Id;
  public string Login;
}

...

// generate TS
var
    ts = new TypeScriptGenerator();
    
// add types you need (dependant types will be added automatically)
ts.AddCSType(typeof(User));

// write to file
File.WriteAllText("Test.ts", ts.ToString());
```
