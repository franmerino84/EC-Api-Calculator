# EC-Api-Calculator

## Table of Contents

[TOC]

## Overview
In these lines I will try to explain some of the decisions taken to solve the code challenge. You're free to contact me if you have any other doubt.

## Application usage
I've built the application as a Web API. It can be run through Visual Studio, or well using the command 'dotnet Ec.Api.Calculator.Presentation.WebApi.dll' over the binaries folder.

I've used Visual Studio 2022, with projects that run over .NET 6, so make sure you have installed the latest version to run it. Probably it works over previous IDE, but I cannot ensure since I haven't tested it.

The endpoints and their corresponding body and headers are the same described in the pdf you provided.

## Architecture of the solution
I have chosen a Design-Driven-Development-like approach while structuring the projects. I have several layers with different responsibilities and visibility. 

### Domain
The Domain layer contains all the entities and main business logic of the application.

### Infrastructure
I've used this project as an utility project available for all other layers.

In my case, I've implemented some exception, IOC, logging, mapping, validating, and static adaptations services that helps a lot to simplify and clean up the other layers, so they can be more focus in their real responsibility.

### Persistence
This layer ensures the persistence of the data in a in-memory-database, and to provide it back for the required queries.

It consumes the Domain layer.

### Application
This layer wrappes the use cases management being independent to the final output, so different possible presentation layers could use it.

The management of each use case covers interactions with the database, logging, and the domain objects and services with their associated business logic.

I've used here a CQRS approach, and different classes for each use case.

It consumes the Domain layer.

### Presentation
The presentation layer is the one in charge of interacting with the end user. It listen for the requests and provide a response in a friendly, standard and understandable, so any final user can take advantage of it.

In this case I decided to use an ASP .NET Core Web API, so it can be used as the backend side of any console, desktop or web application. It can be even used through Swagger (only while debugging), or by any other http client, like Postman.

It consumes the Infrastructure and Application layers. 

### Test
The test layer, can be considered outside the application itself, since it has the responsability to ensure every piece of the software works at expected.

I've mimic the projects and directories structure of the rest of the application inside this layer to get easy access to the corresponding test class of a specific class.

I've also created a Test helpers project to contain some common logic of the tests, so it can be reused.

Most of the tests are Unit, to guarantee the input and output of every method, property and function in all classes, but there are also some Integration tests for the Persistence layer, so I can ensure it works as expected in a real environment.

This layer consumes its corresponding tested layer project.



## Technologies, design patterns, processes, and other concerns

### Target framework - .Net 6
All the projects are built over the framework .NET 6. I considered it because it's an LTS release.

### Screaming Architecture
Recently I heard of this way to structure the directory and files inside a project and I considered very interesting.

I've seen and worked on multiple projects where the files are organized by its nature. So for example there's a directory Controllers, where there are only controllers. Other directory (or big file) for mappings. Another for view models. Another for exceptions. Another for services, etc.

This way of structuring a project has advantages in the sense of you can have a global idea of what kind of things are being done in any of this directories. The big disadvantage here is that there's not any trace between all the classes required to other single class. That can lead to forget some configuration actions (like dependencies injections, or mapping registers).

The key of Screaming Architecture is that, for all those classes that are only used from the same family of classes, to be stored under the same entity directory, and/or use case directory.

So for example, in the presentation layer we have (under the controllers directory, that I respected because of the standard of this key name) a directory for the Calculators, and other for the Journals. Inside them, we have another directory for each use case. In our case a use case it's an endpoint. And inside the use case directory, we have all the controller file, dtos classes and mapping classes.

Just to clarify, I've not created a specific controller per use case, but used the same controller as a partial class.

I'm not very fan of partial classes, but in this case works like a charm, since another typical issue is having very big controller classes that are difficult to read.

### Object Oriented Programming
I've tried to make use of OOP techniques over all the solution. Making use of interfaces, abstract classes, generic types, and inheritance.

Many of my helpers classes are based on OOP and reflection, so it can automate lot of registrations.

### Repository pattern
In order to keep the database logic over the persistence layer, in special about all related to queries, it has been interesting to use this pattern.

### MediaTR (Mediator pattern)
I've use the nuget MediaTR to cover two different aspects.

For one side, it implements the Mediator pattern that liberates from the injecting explosion issue on the constructor of the controllers.

It just map where to call when receiving an object of certain type, and return its corresponding reponse type if defined.

I've used this approach for the calls from the Presentation layer to the Application layer.

### CQRS pattern
I've implemented the CQRS pattern in the application layer. So, also supported by the Screaming Architecture, I've isolated the actions that just queries the state, from others that actually modifies it.

This split has two main utilities. One for clarity of the reader, to ensure if executing some code has side effects or not. The other is to be able to manage the performance or the access to the databases making distinction between these two kind of access.

The ideal would have been to take this pattern to other layers, but I'll leave it for the next steps section.

### Automapper and factories
I've used the nuget Automapper to translate classes between different layers. From dtos to application classes parameters, and from application classes parameters to domain entities mainly.

### NLog logging
I've used NLog nuget to help in the task of creating logs of the application.

I've created a default NLog.config file that configures the logging by creating a log file per day, and also in the console window. It supports to use other targets like AWS CloudWatch, or Elastic Search, but they weren't required.

I've also disable some Microsoft standard logging because of clarity of the created logs, but it can be enabled easily.

I've put the responsibility of logging in the Application layer.

### SOLID
I've tried to follow SOLID guidelines across the whole solution.

#### Single responsibility principle
Each class, except for the repositorie, has only one responsibility. I've tried to separate through use cases all the functionality so they are not so big an have a comprehensive semantic.

#### Open-closed principle
Not much inheritance in the code.

#### Liskov substitution principle
Every override in the inheritance or interface implementation consider the expected behavior of the parent, so this principle is not violated.

#### Interface segregation principle
There are not much interfaces, but well, I just had this in mind.

#### Dependency inversion principle
All business-related classes and third parties are used through dependency injection in the constructor. I've created some static classes, but only over generic helpers.

### Clean code
I've tried to keep the code as readable as I can. For that, I've followed the following approaches:

* Not very big classes
* Having comprehensive, standardize and logical names for directories, projects, interfaces, classes, properties, fields, methods, functions, parameters and variables
* Avoid unnecesary comments
* Extract to methods or functions reusable blocks of code and parts of code very long if make sense
* Following same coding style and organization along the whole code

### Testing
I've used NUnit as test driver, and created unit tests for almost every class.

I've used Moq nuget to Mock interfaces and classes methods and functions.

### Exception handling
I've created a bunch of custom exceptions for different situations in the use cases. The application layer is catching, logging, and rethrowing them. The presentation layer is catching them again and transforming into the appropriate http responses.

The middleware adapts the response in case of errors to the specification.

All non-custom exceptions that are catch by the application layer are transformed into an UnexpectedApplicationException, so the presentation layer can return a 500 Internal Server Error.

So the application layer only throws custom exceptions, and argument exceptions if their parameters have problems.

### Reflection
Sometimes is demonized, but I consider Reflection a very useful util that the framework offers. In this solution I've used it to collect classes that implements or extends an interface or class and add them to some specific configuration.

I've used it to collect:

* Dependency injection
* Mapping (for Automapper)
* Mediator handlers (for MediaTR)


## Next steps
This is a list of next steps I would follow in a real application:
* Add end to end tests
* Manage CancellationToken
* Protect the API through authentication and/or authorization
* Dockerize API
* CICD
* API versioning
* Application versioning
* Real database storage
* Get deeper in CQRS approach, and reach it to the Repository layer

---

Thanks for the opportunity. I hope you enjoy this solution!

Francisco Javier Merino Gallardo
