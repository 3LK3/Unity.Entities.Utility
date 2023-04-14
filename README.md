# 3lk3 Unity.Entities.Utility

Have a look at the full documentation here: <br>
[https://3lk3.github.io/Unity.Entities.Utility](https://3lk3.github.io/Unity.Entities.Utility)

There also is an [example project](https://github.com/3LK3/Unity.Entities.Utility.Examples) demonstrating the main features.

## Installation

### Via Package Manager Window

- Open the Unity package manager via **Window** -> **Package Manager**.<br>
- Click the plus icon on the top left and select **Add package from git URL** 
- Use `https://github.com/3LK3/Unity.Entities.Utility.git` as URL.

### Via manifest.json

Add the repository as a dependency manually to your `<YourProject>/Packages/manifest.json`.

```json
{
  "dependencies": {
    "...",
    "party.elke.unity.entities.utility": "https://github.com/3LK3/Unity.Entities.Utility.git#0.0.1"
  }
}
```

You can choose a specific version [from this list](https://github.com/3LK3/Unity.Entities.Utility/releases).


## Project development

### Documentation

You can build and view this documentation project locally - we recommend that you activate `a local Python virtual environment first <https://packaging.python.org/en/latest/guides/installing-using-pip-and-virtual-environments/#creating-a-virtual-environment>`_:

```bash
    # Install required Python dependencies (Sphinx etc.)
    pip install -r Docs~/requirements.txt

    # Run Jupyter Book
    jupyter-book build Docs~/
```