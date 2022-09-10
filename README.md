# Makoto Studio Logger - Package


[![Manual](https://img.shields.io/badge/docs-Manual-informational.svg)](https://unity-packages.makotostudio.ch/MakotoStudioLogger/Overview)

[![Roadmap](https://img.shields.io/badge/docs-Roadmap-yellowgreen.svg)](https://unity-packages.makotostudio.ch/MakotoStudioLogger/Roadmap)

![GitHub issues](https://img.shields.io/github/issues-raw/MakotoStudio-Games/games.makotostudio.logger)

![GitHub pull requests](https://img.shields.io/github/issues-pr/MakotoStudio-Games/games.makotostudio.logger)

## Overview

Unity advanced custom logger from Makoto Studio - 
improved logging with with formatted log out put time stamp and class reference override the default Unity Debug log or replace it completely.
For more information see Documentation

## Example
```csharp
private static MakotoLogger _LOGGER = new MakotoLogger(typeOf([your_class_here]))
```

```csharp
public class ExampleClass {
    private static MakotoLogger _LOGGER;
    
    private void Awake(){
        _LOGGER = new MakotoLogger(typeOf(ExampleClass));
    }
    
    public void MyFunction() {
        _LOGGER.Log("Log some stuff");
    }
}
```