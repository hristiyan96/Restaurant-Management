# Architecture Notes

## Layers

- Presentation: MVC controllers + Razor views
- Business logic: service interfaces and implementations
- Persistence: Entity Framework Core DbContext and entities

## Design goals

- Keep controllers thin and route business rules through services
- Use dependency injection for testability
- Separate admin features with MVC Area boundaries
