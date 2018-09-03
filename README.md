# ProjectUnicorn

## Build your own application based in this technologies `->`
1. Create ASP.NET Core `2.0 >` application.
    - Use Empty template.
2. Add your favourite Angular version.
    - You can use this [Angular 6 Step-by-Step Guide](https://dzone.com/articles/create-an-application-with-angular-6-and-net-core)
> This guide may not work in future version Angular or ASP.NET Core versions.
> You can use your favourite guide.
3. If you have got 0 exceptions after install Angular, you can add Electron.NET to your project.
> Electron can build your web application like `Stand Alone`.
4. You can use this [Electron.NET Step-by-Step Guide](http://www.cross-platform-blog.com/electron.net/electron.net-musicplayer-app-with-asp.net-core/) for install electron to your project.
# Before you start build your application using Electron.NET
## Check you'r .csproj file and remove angular build string from this code block.

```
<PropertyGroup>
    <TargetFramework>netcoreapp2.0</TargetFramework>
    <TypeScriptCompileBlocked>true</TypeScriptCompileBlocked>
</PropertyGroup>
```

# Good luck, Have fun :3

###### Secret project with open source code :3