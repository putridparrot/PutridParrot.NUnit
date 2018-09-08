# PutridParrot.NUnit

NUnit extensions, includes the TestInputsAttribute class which will generate "edge" test cases 
for different method parameters.

_This is very much in initial design phase._

Current implementation will simple generate null's, empty and non-empty inputs for different types.

To use simply create a test method which has the same arguments (and types) as the method to be 
"input tested". Then mark your methods as a TestInputs method, for example

```csharp
[TestInputs]
public void Mean(double[] values)
{
   Statistics.Mean(values);
}
```

TODO: 

1. Better edge case or maybe random data generation
2. Ability to ignore test cases where it's preferred 
   to not use the test data

