# SimpleWebSharp  
A lightweight and easy-to-use library for making web requests in C#.  
Built with .NET 8.0.  

## Features  
- Simple and intuitive API for GET and POST requests  
- Synchronous and asynchronous variants available  
- Handles HTTP status codes and errors gracefully  

## Installation  
Simply add the `Web` library to your project and start making requests.  

## Usage  

### Basic GET Request  
```cs
string serverResponse = Web.Get("https://example.com");
```
### GET Request with Callback
```cs
Web.Get("https://example.com", (message, status) => {
    Console.WriteLine($"Response: {message}");
    Console.WriteLine($"Status Code: {status}");
});
```
- message: The response from the server (as a string)
- status: The HTTP status code (e.g., 200, 404, 500; 0 if the connection fails)

### Basic POST Request
```cs
string serverResponse = Web.Post("https://example.com", "data=example");
```
POST Request with Callback
```cs
Web.Post("https://example.com", "data=example", (message, status) => {
    Console.WriteLine($"Response: {message}");
    Console.WriteLine($"Status Code: {status}");
});
```
### Asynchronous Usage
If you need to run web requests in an asynchronous task:
```cs
await Task.Run(async () => {
    string result = await Web.GetAsync("https://example.com");
    Console.WriteLine(result);
});
```
> **Note:** The asynchronous methods (`GetAsync`, `PostAsync`) must be awaited inside an `async` method or `Task.Run` if used outside the main thread.

GetAsync also works with callbacks, such as PostAsync.
