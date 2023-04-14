# Requirements

I assume you:
- are using Unity >= 2022.2.12f1
- have a Unity project configured with [Entities](https://docs.unity3d.com/Packages/com.unity.entities@1.0/manual/) and [Unity.Physics](https://docs.unity3d.com/Packages/com.unity.physics@1.0/manual/)
- have an understanding of basic Entities concepts

# Installation

There are two ways of installing a package in Unity. You can add a dependency to the `manifest.json` in your Packages folder or install it via the Unity package manager.

## Add dependency to manifest.json

Declare this package as a dependency in `<Your Project>/Packages/manifest.json` by adding the following line to the *dependencies* section:

> [!Note]
> You can replace the version specifier with any [valid release version](https://github.com/3LK3/Unity.Entities.Utility/releases) or just remove it to use the latest version.

```json
{
  "dependencies": {
    "...",
    "party.elke.unity.entities.utility": "https://github.com/3LK3/Unity.Entities.Utility.git#0.0.1"
  }
}
```

## Use the Unity package manager

- Open the Unity package manager via **Window** -> **Package Manager**.<br>
- Click the plus icon on the top left and select **Add package from git URL** 
- Use `https://github.com/3LK3/Unity.Entities.Utility.git` as URL.