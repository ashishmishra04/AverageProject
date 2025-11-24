# AverageProject

A small C# project that demonstrates computing the average that lets you track the average of numerical values.
There should be a way to add new values and also query the current average of all values added to the object.

Project structure
- `AverageProject/` - main project (library/console) targeting .NET 8
- `AverageProjectTest/` - unit tests for the project

Prerequisites

- .NET 8 SDK installed (https://dotnet.microsoft.com/download)

Build

From the repository root run:

- `dotnet build`

Run

If the main project is a console app, run:

- `dotnet run --project AverageProject/AverageProject.csproj`

Tests

Run unit tests from the repository root:

- `dotnet test`

Useful notes

- The project targets .NET 8.
- See `AverageProject/Average.cs` and `AverageProject/Program.cs` for implementation details.
- See `AverageProjectTest/AverageTest.cs` for the test cases.
