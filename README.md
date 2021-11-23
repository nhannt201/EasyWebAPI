# EasyWebAPI

[![Nuget](https://img.shields.io/nuget/v/EasyWebAPI?label=NuGet&logo=nuget)](https://www.nuget.org/packages/EasyWebAPI/)
[![NuGet](https://img.shields.io/nuget/dt/EasyWebAPI.svg)](https://www.nuget.org/packages/EasyWebAPI)


An extension that makes Get and Post to Web API easily and fast.

# Guide - QuickStart

### POST File to API without Header:

```cs
EasyWebApi.addFile("<your-path-file", "your-files-key", "your-file-name.extensions-value");
string responseString = EasyWebApi.postFile("<your-url-api");
```

### POST File to API with Header:

```cs
EasyWebApi.addFile("<your-path-file", "your-files-key", "your-file-name.extensions-value");
EasyWebApi.addHeader("value", "key"); //You can add multiple Headers
string responseString = EasyWebApi.postFile("<your-url-api", true);
```

### POST Header to API without File:

```cs
EasyWebApi.addHeader("value", "key"); //You can add multiple Headers
string responseString = EasyWebApi.postHeader("<your-url-api");
```

### GetString from API

```cs
string responseString = EasyWebApi.getContent("<your-url-api");
```

### Get Status Code

```cs
int StatusCode = EasyWebApi.getStatusCode;
```

# License

The source code is licensed under the MIT license.