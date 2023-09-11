# .NET Template (Unfinished Project)

**Author:** Oste Jannick  
**Description:** This is the startup configuration where all your dependencies' configuration and injection occur.  
**Start-Date:** 2023-09-11

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

## Dependencies

### Entity Framework Core

The project leverages Entity Framework Core to facilitate database operations. The `DatabaseContext` class serves as the central hub for managing interactions with the database.

### Repository Pattern

Efficiency and flexibility are key in this project. The repository pattern is implemented with lazy repository injection, allowing for the dynamic creation of repositories for all entities marked with the `RepositoryTarget` attribute.

## Configuration

The heart of the project lies within the `Startup` class. Here, you'll find the essential configurations:

- **Database Context**: The `DatabaseContext` is added to the services, providing a centralized mechanism for database interactions.

- **Lazy Repository Injection**: Repositories for entity types with the `RepositoryTarget` attribute are injected on-demand, reducing the need for repetitive manual setup.

- **Controller Initialization**: Controllers and Swagger API documentation are initialized, ensuring seamless integration with the project.

## Database Repository

For efficient database operations on entities, the `DatabaseRepository<TEntity>` class implements the `IDatabaseRepository<TEntity>` interface. This class offers essential methods for entity management, including insertion, retrieval, updating, and deletion.

## User Model

The `User` class represents a fundamental entity within the project. It encapsulates essential user-related properties, such as username, name, email, user scope, date of birth, and email confirmation status. The `RepositoryTarget` attribute designates it for integration with the repository pattern.

## Mapper Generation

To further streamline data mapping between various models, a dynamic mapper generation feature is included. This feature automatically generates mappers for mapping data from input models to entity models, simplifying the data transformation process.

### Entity Mappers

- **EntityCreateViewMapTargetAttribute**: This attribute is used to specify the target type for automatic create mapper generation. Apply this attribute to your destination model (entity) classes to streamline the mapping process.

- **EntityUpdateViewMapTargetAttribute**: Similar to the create mapper attribute, this attribute is used for automatic update mapper generation. It simplifies the mapping of updates from view models to entities.

- **IEntityCreateMapper\<Source, Destination\>**: An interface for creating mappers that map data from source models to destination models. It allows for custom mapping logic.

- **IEntityUpdateMapper\<Source, Destination\>**: An interface for creating mappers that map update data from source models to destination models. It supports custom mapping logic and updating only non-null properties.

Explore the project's configurations, repository patterns, and data mapping capabilities to build efficient and scalable .NET applications.

(Readme is not done yet, temporary eod commit)