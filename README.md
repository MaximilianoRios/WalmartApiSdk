# WalmartApiSdk
.Net SDK to access Walmart Open API

Current version: 1.0.0.0

# How to use it

The current version only implements products search. It is intended to add the rest of the API methods in future versions.
Accessing the API is very simple, first, it is necessary to create a WalmartWrapper object including your API key. 
If you don't have a key go to https://developer.walmartlabs.com/ and create an account to get your own key.
Once you have a key you can create the object with the following code:

```c#
var apiKey = "your api key";
var wrapper = new WalmartWrapper(apiKey);
```

The simplest search consists of a phrase. There are always two methods, a synchronous method and the async one.
This is an example of an async call:

```c#
Task.Run(async () =>
{
	var response = await wrapper.SearchAsync("phrase to search");
});
```

The synchronous call is always the same method name without the Async prefix.



The wrapper assumes Json as a default format, there is not any difference on using Json or Xml, the wrapper uses an
agnostic model that is a contract that both serializers must implement in order to unify the output. 
The response is a IWalmartSearchResponse object instance with a rich set of information.

Every other parameter rather than the search is optional. It is possible to search by category id (it requires to
know in advance the id from the taxonomy API, not implemented yet in this version), change the format (Json/XML)
and implement facets.

# Facets

Facets are filters to be applied to a search. Walmart sends back the available facets after searching for products
with the facet flag On. It is not possible to know the filters before searching, they're dynamically generated.

The list of available facets is returned in the IWalmartSearchResponse. The simplests way to use it is calling
facets by name and value. To be able to implement facets easier a FacetsFilterBuilder is created and helps to 
construct the dictionaries.
There are two types of facets and they're both optional in the search, key/value and range. The facets builder
supports both of them:

Example:

```c#
facetsBuilder.AddFilter("retailer", "Odyssey Computers");
facetsBuilder.AddRange("price", 100, 200);
```

Ranges require from/to values and they're mostly always numeric. 

The builder contains two properties that can be passed to the search:

```c#
facetsBuilder.Filters;
facetsBuilder.Ranges;
```

In the ConsoleTest project it is possible to see them working with a functional search.

# Exceptions

Any internal problem is converted into an exception and thrown to the caller. It's always required to implement
a try/catch block. Errors in the specific access to the Walmart Open API are captured and wrapped into a
WalmartOperationException. Other issues like incorrect builder information are wrapped into different exceptions.

For more information about the Walmart Open API please visit:

https://developer.walmartlabs.com/

There is a rich set of information including documentation, console to test the API, Forum and blogs.

# Author Notes

This project was created for a personal project, trying to implement the SDK in the cleanest way possible.
Please send me your comments and requests to improve the API. I plan to add more features soon.


