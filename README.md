# Jakar.Core

Base types shared by the Jakar.* packages: BaseClass, IObservableObject, IJsonModel and the equality/comparison operator interfaces.

```sh
dotnet add package Jakar.Core
```

It depends on [Jakar.Json](https://www.nuget.org/packages/Jakar.Json/); the types are in the `Jakar.Extensions` namespace.

## What's in it

- `BaseClass` / `BaseClass<TSelf>`: property-change notifications, `[JsonOverflow] AdditionalData`, disposal and equality scaffolding.
- `IObservableObject`, `IJsonModel`, `IEqualComparable<TSelf>` and the operator interfaces.


## Versioning

Versions are `<.NET major>.<library major>.<library minor>`: a breaking change bumps the middle number (`10.1.0` → `10.2.0`), anything else the last one.

## Repository

| Path | What it is |
|---|---|
| `Jakar.Core/` | The package. |
| `Jakar.Core.Tests/` | NUnit tests. |
| `.github/workflows/ci.yml` | Build and test on Ubuntu and Windows, for every push and pull request. |
| `.github/workflows/publish.yml` | On `master`: CI, then pack and push to nuget.org (Trusted Publishing). |