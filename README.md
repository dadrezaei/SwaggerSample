# SwaggerSample
swagger guide: API documentation for .net core

## How to create web API using asp.net core 3.1

In this step, we will create a new ASP.NET Core 3.0 Web API using Visual Studio 2019. So, open visual studio, click on "Create a new project", and then select "ASP.NET Core Web Application". Click on the "Next" button. Then enter the name of your project, and then the location of your project. Then click on the "Create" button. Then select asp.net core version from the upper dropdown and then click on the "API" template and then finally click on the "Create" button.
> 
After creating the project, add "Swashbuckle.AspNetCore" package from "Manage NuGet Packages" or with this command:
> 
`PM> Install-Package Swashbuckle.AspNetCore -Version 5.5.1`
> 
Now, right-click on project => select properties => go to "Build" tab, and then check the "XML documentation file:" box
![](https://i.stack.imgur.com/TbVwq.png)

Good job! Now create a JSON file in "/swagger/v1/swagger.json".
> 
In the next step, open "Startup.cs" file and then add the following code to "ConfigureServices" method:
>       services.AddSwaggerGen(option =>
>             {
>                 option.SwaggerDoc("v1",
>                     new OpenApiInfo()
>                     {
>                         Title = "your project title",
>                         Version = "v1",
>                         Description = "your project Description"
>                     });
>                 var filePath = Path.Combine(System.AppContext.BaseDirectory, "SwaggerSample.xml"); //name of XML file in pervious step!
>                 option.IncludeXmlComments(filePath,true); //to add XML comments that are above our methods
>             });
> 
And the following code to "Configure" method:
> 
>            app.UseSwagger();
>            app.UseSwaggerUI(c =>
>             {
>                 c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger Sample API Helper");
>             });
Done!

For more information please see the summary example in Controller.
