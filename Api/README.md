# .NET Template (Unfinished Project)

Outdated needs updates

## Table of Contents

- [Introduction](#introduction)
- [Dependencies](#dependencies)
- [Configuration](#configuration)
- [Database Repository](#database-repository)
- [User Model](#user-model)
- [Mapper Generation](#mapper-generation)
  - [Entity Mappers](#entity-mappers)

## Introduction

Welcome to the `netcore` project's startup configuration repository. This repository focuses on simplifying the setup of dependency configurations, injection, database repository management, and entity model mapping.

## Configuration

The heart of the project lies within the `Startup` class. Here, you'll find the essential configurations:

- **Database Context**: The `DatabaseContext` is added to the services, providing a centralized mechanism for database interactions.

- **Lazy Repository Injection**: Repositories for entity types with the `RepositoryTarget` attribute are injected on-demand, reducing the need for repetitive manual setup.

- **Controller Initialization**: Controllers and Swagger API documentation are initialized, ensuring seamless integration with the project.

## Database Repository

For efficient database operations on entities, the `DatabaseRepository<TEntity>` class implements the `IDatabaseRepository<TEntity>` interface. This class offers essential methods for entity management, including insertion, retrieval, updating, and deletion.

## Mapper Generation

To further streamline data mapping between various models, a dynamic mapper generation feature is included. This feature automatically generates mappers for mapping data from input models to entity models, simplifying the data transformation process.


## Getting Started

To begin using the NetCore template, follow these steps:

### Creating a Model Interface

In the `App.Example.Domain.Models` namespace, create an interface for your product model. The interface should define the properties that a product must have. Here's an example:

```csharp
namespace App.Example.Domain.Models
{
    public interface IProduct
    {
        int Id { get; set; }
        string Name { get; set; }
        decimal Price { get; set; }
    }
}
```

### Creating a Model

Create a model for your product by implementing the `IProduct` interface. Additionally, use the `[PrimaryKey]` and `[DbEntity]` attributes to define how the model should be mapped to the database. Here's an example:

```csharp
using App.Core.Domain.Database;
using Microsoft.EntityFrameworkCore;

namespace App.Example.Domain.Models
{
    [PrimaryKey(nameof(Id))]
    [DbEntity(typeof(Product))]
    public class Product : IProduct
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; } = 0.0M;
    }
}
```

### Creating ViewModels

In the `App.Example.Infrastructure.ViewModels` namespace, create view models for your product. You can use the `[SetEntityRemapper]` attribute to auto-generate mappers for mapping between view models and the target type (e.g., `Product`). Here's an example of a view model:

```csharp
using System.ComponentModel.DataAnnotations;
using App.Core.Domain.Mappers.Entity;
using App.Example.Domain.Models;

namespace App.Example.Infrastructure.ViewModels
{
    [SetEntityRemapper(mapTo: typeof(Product))]
    public class ProductCreateViewModel 
    {
        [Required] public string Name { get; set; } = string.Empty;
        [Required] public decimal Price { get; set; } = 0.0M;
    }
}
```

### Creating a Controller

To manage products, create a controller with the necessary actions. Use dependency injection to inject services such as the repository and entity mappers. Here's an example of a controller:

```csharp
using Microsoft.AspNetCore.Mvc;
using App.Core.Domain.Database;
using App.Core.Domain.Mappers.Entity;
using App.Example.Domain.Models;
using App.Example.Infrastructure.ViewModels;

[Route("[controller]")]
public class ProductController : Controller
{
    private readonly IDatabaseRepository<Product> repository;
    private readonly IEntityRemapper<ProductCreateViewModel, Product> createMapper;
    private readonly IEntityRemapper<ProductUpdateViewModel, Product> updateMapper;

    public ProductController(
        IDatabaseRepository<Product> repository,
        IEntityRemapper<ProductCreateViewModel, Product> createMapper,
        IEntityRemapper<ProductUpdateViewModel, Product> updateMapper
    )
    {
        this.repository = repository;
        this.createMapper = createMapper;
        this.updateMapper = updateMapper;
    }

    // Add your product management actions here
}
```

With these steps, you have set up the foundation for managing products in your project. You can now create, retrieve, update, and delete products using the provided structure and dependency injection.

Feel free to expand upon this foundation to build a complete product management system tailored to your specific requirements.