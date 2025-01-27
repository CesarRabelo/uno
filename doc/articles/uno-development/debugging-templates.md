# Debugging Uno Platform Solution templates

The uno platform project contains multiple types of templates:
- `dotnet new` templates
- Visual Studio (2019/2022) Extensions templates (vsix)

Some of the templates are reusing the same sources. For example the full solution template is defined in the vsix project, and building the `dotnet new` template creates a transformed version of the vsix template.

## VSIX Templates

VSIX templates are using the Visual Studio extensibility model, and run with a specific project type.

To make modifications to those templates and test the result:
- In Visual Studio, open the solution using the [Uno.UI-SolutionTemplates.slnf](building-uno-ui.md) filter
- Right click on the `UnoSolutionTemplate.VSIX.2022` or `UnoSolutionTemplate.VSIX.2019` project then debug
- A new isolated testing instance of visual studio will open, allowing you to create projects using modified templates

## dotnet new templates

`dotnet new` new templates use the dotnet/templating engine, and are located in the `src/SolutionTemplate/Uno.ProjectTemplates.Dotnet` folder.

To make modifications to those templates and test the result:
- In Visual Studio, open the solution using the [Uno.UI-SolutionTemplates.slnf](building-uno-ui.md) filter
- Right click on the `Uno.ProjectTemplates.Dotnet` project, select `Pack`
- This will create a `Uno.ProjectTemplates.Dotnet.255.255.255.255.nupkg` file
- Install this file using `dotnet new -i C:\[your_path]\bin\Debug\Uno.ProjectTemplates.Dotnet.255.255.255.255.nupkg`
- In another temporary folder, create a new application using the updated templates with `dotnet new unoapp -o MyTestUnoApp01`

Ensure that the application runs properly by building it in Visual Studio and running it on all targets.

Once you're done with debugging the templates, you can go back to the official templates with:

```
dotnet new -i Uno.ProjectTemplates.Dotnet
```
