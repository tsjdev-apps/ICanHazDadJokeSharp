# ICanHazDadJokeSharp

A simple .NET wrapper for the website [ICanHazDadJoke.com](https://www.icanhazdadjoke.com) to get random dad jokes.

## Screenshots

![Sample Screenshot](https://raw.githubusercontent.com/tsjdev-apps/ICanHazDadJokeSharp/main/docs/sample-screenshot.png)

## Setup

Available on NuGet: [ICanHazDadJokeSharp](https://www.nuget.org/packages/ICanHazDadJokeSharp)

[![NuGet](https://img.shields.io/nuget/v/ICanHazDadJokeSharp.svg?label=NuGet&color=blue)](https://www.nuget.org/packages/ICanHazDadJokeSharp)

Just add the package to your .NET application.

## Usage

You need to provide a `name` and some `contact details` which are used to create a custom User-Agent for the requests. Please see [https://icanhazdadjoke.com/api#custom-user-agent](https://icanhazdadjoke.com/api#custom-user-agent) for further information.

```csharp
var name = "<Your Library Name>";
var contactDetails = "<Your Library Contact Details>";

var client = new DadJokeClient(name, contactDetails);

var joke = await client.GetRandomJokeAsync();
```