# Contool

Automatic service register for Microsoft.Extensions.DependencyInjection


## Installation

### .NET CLI
```
dotnet add package Contool
```

### Package Manager
```
NuGet\Install-Package Contool
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
