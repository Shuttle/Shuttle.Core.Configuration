# Shuttle.Core.Configuration

> **Warning**
> This package has been deprecated in favour of the [options pattern](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/options).

```
PM> Install-Package Shuttle.Core.Configuration
```

This package provides access to the existing .Net configuration system provided by `ConfigurationSection` classes.

## ConfigurationSectionProvider

``` c#
public static T Open<T>(string name) where T : ConfigurationSection
public static T Open<T>(string group, string name) where T : ConfigurationSection
public static T OpenFile<T>(string name, string file) where T : ConfigurationSection
public static T OpenFile<T>(string group, string name, string file) where T : ConfigurationSection
```

## ConfigurationItem

Returns an `appSetting` entry value.