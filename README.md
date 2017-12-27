# Shuttle.Core.Configuration

## ConfigurationSectionProvider

``` c#
public static T Open<T>(string name) where T : ConfigurationSection
public static T Open<T>(string group, string name) where T : ConfigurationSection
public static T OpenFile<T>(string name, string file) where T : ConfigurationSection
public static T OpenFile<T>(string group, string name, string file) where T : ConfigurationSection
```

## ConfigurationItem

Returns an `appSetting` entry value.