# Environment Config Sample

Demo showing how to do environment specific configuration in .Net Core

## Introduction

In the `EnvironmentConfig/Config` folder are three files:

* appsettings.json
* appsettings.Staging.CA.json
* appsettings.Staging.UK.json

The `ConfigurationLoader` class is set up using the new `ConfigurationBuilder` logic in .Net Core to load these files based on the programs arguments.

The `appsettings.json` is the default, whilst any keys present in the overrides like `appsettings.Staging.CA.json` will overwrite the defaults for us.

The arguments specifying which environment and tenant we are in are passed to the program, e.g:

```bash
dotnet run Staging CA
```

## Prerequisites

* .Net SDK 2.1.2 or higher: https://www.microsoft.com/net/learn/get-started/windows

## Setup

Run the following in the `EnvironmentConfig` project folder:

```bash
dotnet restore
dotnet build
```

## Running The Application

Run the following in the `EnvironmentConfig` project folder.

To use the default `appsettings.json` config with no environment or tenant overrides, use:

```bash
dotnet run
```

To pass in the environment and tenant to override the default configuration, use:

```bash
dotnet run Staging CA
```