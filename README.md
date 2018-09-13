# ProjectUnicorn

## Build your own application based in this technologies `->`
1. Create ASP.NET Core `2.0 >` application.
    - Use Empty template.
2. Add your favourite Angular version.
    - You can use this [Angular 6 Step-by-Step Guide](https://dzone.com/articles/create-an-application-with-angular-6-and-net-core)
> This guide may not work in future version of Angular or ASP.NET Core.
> You can use your favourite guide.
3. If you have got 0 exceptions after install Angular, you can add Electron.NET to your project.
> Electron can build your web application like `cross platform` `Stand Alone Desktop Application`.
4. You can use this [Electron.NET Step-by-Step Guide](http://www.cross-platform-blog.com/electron.net/electron.net-musicplayer-app-with-asp.net-core/) for install Electron to your project.
# Before you start build your application using Electron.NET
## Check your .csproj file and remove angular build string from this code block.

```
<PropertyGroup>
    <TargetFramework>netcoreapp2.0</TargetFramework>
    <TypeScriptCompileBlocked>true</TypeScriptCompileBlocked>
</PropertyGroup>
```
# All important build, start and deploy console commands you can see in `gulpfile.js`.

- [x] Good luck.
- [X] Have fun.
- [ ] 50 shades of exception :3

###### Secret project with open source code :3