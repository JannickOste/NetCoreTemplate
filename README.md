# .net template 
(project unfinished)

**Author:** Oste Jannick  
**Description:** This is the startup configuration where all your dependencies' configuration and injection occur.  
**Start-Date:** 2023-09-11

## Table of Contents

- [Introduction](#introduction)
- [Dependencies](#dependencies)
- [Configuration](#configuration)
- [Database Repository](#database-repository)
- [User Model](#user-model)

## Introduction

This repository contains the startup configuration for the `netcore` project. It includes dependency configuration and injection, database repository implementation, and a user model.

## Dependencies

### Entity Framework Core

This project utilizes Entity Framework Core for database operations. The `DatabaseContext` class handles database interactions.

### Repository Pattern

Lazy repository injection is employed for all entities marked with the `RepositoryTarget` attribute. This allows for dynamic repository creation.

## Configuration

The `Startup` class is where dependency injection and configuration occur. Here's a brief overview:

- Database context (`DatabaseContext`) is added to services.
- Repositories for all entity types with the `RepositoryTarget` attribute are injected lazily.
- Controllers and Swagger API documentation are initialized.

## Database Repository

The `DatabaseRepository<TEntity>` class implements the `IDatabaseRepository<TEntity>` interface for basic database operations on entities. It includes methods for inserting, retrieving, updating, and deleting entities.

## User Model

The `User` class represents a user entity. It includes properties such as username, name, email, user scope, date of birth, and email confirmation status. The `RepositoryTarget` attribute marks it for inclusion in the repository pattern.


(Readme is not done yet, temporary eod commit)