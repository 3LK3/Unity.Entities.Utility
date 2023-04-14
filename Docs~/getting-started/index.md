# 3lk3 Unity.Entities.Utility

It's a collection of extensions and helper mechanisms to implement applications in Unity using DOTS and ECS.

## Terminology

- *Entity* refers to an [Unity ECS Entity](https://docs.unity3d.com/Packages/com.unity.entities@1.0/manual/concepts-entities.html)
- *World* refers to an [Unity ECS World](https://docs.unity3d.com/Packages/com.unity.entities@1.0/manual/concepts-worlds.html)

## Features

This package provides solutions to common problems I faced during development with Unity.

There are **helpers for any Unity application**:
- Base class for singletons
- Displaying frames per second
- `ReadOnly`-Attribute for fields displayed in the Inspector
- Some array extension methods

as well as **DOTS specific features**:
- Custom world initialization mechanism to create Systems only in specfic worlds
- Loading a new Unity scene with a new corresponding world
- Physics `HitCollector` for a specific entity




