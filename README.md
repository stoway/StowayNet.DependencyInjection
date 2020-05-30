<p align="center">
  <img height="80" src="https://s.gravatar.com/avatar/6275a0046443d6fb33421b52e503bc3e?s=140">
</p>

# StowayNet.DependencyInjection 　　　　　　　　　　　[En](https://github.com/stoway/StowayNet.DependencyInjection/blob/master/README.en-us.md)
 StowayNet.DependencyInjection 是基于 .net core 框架中的依赖注入实现的扩展方法，它可以帮助您在项目中更简捷的实现依赖注入。

## 入门
### NuGet 

你可以运行以下下命令在你的项目中安装 StowayNet.DependencyInjection。

```
PM> Install-Package StowayNet.DependencyInjection
```

### 配置

首先配置 StowayNet.DependencyInjection 到 Startup.cs 文件中，如下：
```c#
public void ConfigureServices(IServiceCollection services)
{
    ......

    services.AddStowayDependency();

    ......
}

```

### 注入方式

#### 
