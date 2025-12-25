# KH_Calculator

## Commands to create the solution

```cmd
mkdir KH-Calculator
cd .\KH_Calculator\
dotnet new sln
dotnet new gitignore
dotnet new xunit --name Test
dotnet new classlib --name Core
dotnet new console --name App
dotnet sln add App
dotnet sln add Core
dotnet sln add Test
dotnet add App reference Core
dotnet add Test reference Core
```

## Prosess

1. Create solution and project
2. Create the tests based on the design
3. Run tests to make sure they fail
4. Implement Core until it passes all tests.
5. Implement a frontend
