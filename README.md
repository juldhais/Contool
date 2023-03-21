# Contool

Automatic service register for Microsoft.Extensions.DependencyInjection


## Installation

### .NET CLI
```
dotnet add package Contool --version 1.0.0
```

### Package Manager
```
NuGet\Install-Package Contool -Version 1.0.0
```


## Usage

### Service Attribute
```
[ScopedService]
public class ScopedUserService : IScopedUserService
{
}

public interface IScopedUserService
{
}
```

### Register Service
```
builder.Services.AddServicesFromAssembly(Assembly.GetExecutingAssembly());
```