# Getting Started BrightSky.DataMock
This is a project that I intended to eventually make it a nuget package which will then serve as an intuitive and easy 
yet useful way to generate mock data for testing purposes.

## Examples for generating `Int32`
```csharp
// Get an int within the default range of 1 - 1000
// where int value will be equal to 1
// or the int value will be less than 1000
var myInt = Dm.Ints().Get();

// Get a List<int> of default size of 100
// where int values are all within the range of 1 - 1000
// where an int value will be equal to 1
// or an int value will be less than 1000
var myIntList = Dm.Ints().ToList();

// Get a List<int> of size of 500
// where int values are all within the range of 1 - 1000
// where an int value will be equal to 1
// or an int value will be less than 1000
var myIntListWithSize = Dm.Ints().ToList(size:500);

// Get an int within the range of 1 - 100
// where int value will be equal to minValue
// or the int value will be less than maxValue
var myIntWithinARange = Dm.Ints().Range(minValue:1, maxValue:100).Get();

// Get a List<int> of default size of 100
// where int values are all within the range of 1 - 100
// where an int value will be equal to minValue
// or an int value will be less than maxValue
var myIntListWithinARange = Dm.Ints().Range(minValue:1, maxValue:100).ToList();

// Get a List<int> of size of 500
// where int values are all within the range of 1 - 100
// where an int value will be equal to minValue
// or an int value will be less than maxValue
var myIntListWithSizeWithinARange = Dm.Ints().Range(minValue:1, maxValue:100).ToList(size:500);
```

### TODD: Complete `Int32` code examples
### TODD: Examples for `Nullable<Int32>` code 
### TODO: Examples for `Boolean` code

