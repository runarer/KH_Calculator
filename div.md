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