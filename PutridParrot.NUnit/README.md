# NUnit specific extensions

## TestInputs
Can be used instead of a TestAttribute around a test method along with arguments that will be passed 
to a method under test. It will then automatically generate a set of TestCases with nulls, empty values 
and/or other "edge" cases relevent to the types.

Useful to just ensure your methods handle any edge case data

For example:

```
[TestInputs]
public void Mean(double[] values)
{
   Statistics.Mean(values);
}
```

In this case the _Statistics.Mean_ method takes a double[], so we pass the same into the test method,
when the test is run the TestInput code creates a number of TestCases which will include an empty array,
a null array, one with a double.MaxValue and with double.MinValue (and possibly more).
