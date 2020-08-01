[![Build status](https://ci.appveyor.com/api/projects/status/4acske7n20xws4oi/branch/master?svg=true)](https://ci.appveyor.com/project/Fyzxs/code-exercise-services/branch/master)

This is a code exercise. It'll be a component of a continuing discussion. It'll have specific emphasis on SOLID principles, which for me means following what I've laid out about [MicroObjects](https://quinngil.com/uobjects/).


## Building Locally
* This is a C# project, use any IDE or tool capable of compiling such. A few I'm familiar with are below.
* * Free - [Visual Studio](https://visualstudio.microsoft.com/vs/community/)
* * Trial - [Rider](https://www.jetbrains.com/rider/)
* * Free - [Visual Studio Code](https://code.visualstudio.com/docs/languages/csharp)
* Run Tests
* * Ensure everything is functioning as expected.
* GroceryImport.sln is the solution file
* * GroceryImport.Core.csproj is the core functionality in .NET Standard
* * GroceryImport.Cli.csproj is the command line UI; in .NET Core

## Existing CI System
* CI is via AppVeyor and is [here](https://ci.appveyor.com/project/Fyzxs/code-exercise-services).
* Build file is `appveyor.yml` in the root.
* * A build file is used for maintainability and enabling making build changes in branches without potentially breaking everything. 

## Usage
* Get the latest artifact from [here](TODO:LINK_ME)
* Execute from the command line as follows
* * `blah blah blah`
* * Also available as `blah -help` or `blah -?`

## Contributing
Don't.
I'm using this to demonstrate and enable discussion on my coding technique. 

## License
[MIT](https://choosealicense.com/licenses/mit/)