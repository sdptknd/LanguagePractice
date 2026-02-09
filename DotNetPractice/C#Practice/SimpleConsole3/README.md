1. This is the exact same as SimpleConsole2, which was created using intellij idea's new solution option. Then I started adding more to that.

2. dotnet command can do all the stuffs, it can even add Nuget (Nuget is the standard repository name for dotnet libraries, like Maven for Java) dependencies to the project and `.csproj` file. `.csproj` file is the build file here, that means it will contain all the information about the C# project, including dependencies. 

3. If you want to run any dotnet command and you're not in project directory (let's say you're in ), then you have to mention the project name in dotnet command. Ex: if you're inside ConsoleApp directory, then you can simply run `dotnet run` to run compile and run ConsoleApp project. However, to do the same from SimpleConsole3, you have to run `dotnet run --project ConsoleApp`.

4. `dotnet clean` command cleans all pre-built artifacts. `dotnet restore` command resolves and installs all dependencies, `dotnet build` builds all csproj files into project dll and places it inside `bin/` directory (it will create the directory if not present) (actually the .dll will be found at `bin/Debug/net<version>/` directory. Also it puts all dependency `dll`s in the same directory. This is how the app runs refering to it's dependencies, that is having all dependency `dll`s in same directory as compiled code dll).`dotnet <path_to_dll>` then runs the dll file if it's an executable dll. (if a project dll is executable or not, that's set in .csproj file under `OutputType` tag under `PropertyGroup` section). `dotnet run` does all of the above in order, but it can only run the dll if it's executable. A detailed list of commands [here](./DotNetCommands.md)

5. a `.dll` file is similar to `.jar` file, both contains compiled code. However, `.jar` is simply a set of compressed files with some metadata, so it can contain other files needed for the project, like images, config files. Also a self contained `.jar` holds class definitions for dependencies as well. However, a `.dll` only contains compiled code. to create a package with complied codes, dependency `.dll`s and other files like image and config etc, we need to create a nuget package.

6. Let's get back to the code. First we can run `dotnet run --project ConsoleApp` to see the output.

7. I've added a third party library to the project as well using `dotnet add package Newtonsoft.Json -v 13.0.1 ` (version part is optional.) This will update the .csproj file of ConsoleApp project to add the dependency. Also notice that `Newtonsoft.Json.dll` is present in the compiled folder adjacent to the compiled .dll.

8. I created a new library type project `Magic` in the solution and added that as a dependency to `ConsoleApp` project using `dotnet add reference ../Magic/Magic.csproj` from ConsoleApp/ directory. the new project is created directly using intellij rider, but you can use dotnet command also to create a new project and then add it to the solution using `dotnet sln add <project>` command.

9. `dotnet run --project Magic` this would always give error as Magic is not an executable project and it's a library project which is set in the Magic project's `.csproj` file

10. The sdk value in .csproj files is `Microsoft.NET.Sdk`. When this is just dotnet core, if we change it to `Microsoft.NET.Sdk.Web` then it comes with asp.net libraries and Kestrel server as well.