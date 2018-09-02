using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using NUnit.Framework.Internal.Builders;

namespace PutridParrot.NUnit
{
    [AttributeUsage(AttributeTargets.Method)]
    public class TestInputsAttribute : TestAttribute, ITestBuilder//, ITestAction
    {
        IEnumerable<TestMethod> ITestBuilder.BuildFrom(IMethodInfo method, Test suite)
        {
            foreach (var p in GetCombination(method.GetParameters().Select(_ => _.ParameterType).ToArray()))
            {
                yield return new NUnitTestCaseBuilder().BuildTestMethod(method, suite,
                    new TestCaseParameters(p));
            }
        }

        private IEnumerable<object[]> GetCombination(Type[] parameters)
        {
            // this is a primitive implementation which
            // creates a lookup of "known" edge cases 
            // for types
            var edges = new Dictionary<Type, object[]>();
            for (var i = 0; i < parameters.Length; i++)
            {
                var type = parameters[i];
                if (!edges.ContainsKey(type))
                {
                    edges.Add(type, GenerateValues(type));
                }
            }

            var maxEdges = edges.Count > 0 ? edges.Select(kv => kv.Value.Length).Max() : 0;
            for (var i = 0; i < maxEdges; i++)
            {
                yield return GenerateArguments(parameters, i, edges);
            }
        }

        private object[] GenerateValues(Type type)
        {
            if (type == typeof(string))
            {
                return GenerateStringValues();
            }
            if (type == typeof(int))
            {
                return GenerateIntValues();
            }
            if (type == typeof(long))
            {
                return GenerateLongValues();
            }
            if (type == typeof(float))
            {
                return GenerateFloatValues();
            }
            if (type == typeof(double))
            {
                return GenerateDoubleValues();
            }
            if (type.IsArray)
            {
                return GenerateArrayValues(type.GetElementType());
            }

            // otherwise non-handle types, assume null is a valid test
            return new object[] { null };
        }

        private static object[] GenerateDoubleValues()
        {
            return new object[] { double.MinValue, 0.0, double.MaxValue };
        }

        private static object[] GenerateFloatValues()
        {
            return new object[] { float.MinValue, 0.0, float.MaxValue };
        }

        private static object[] GenerateLongValues()
        {
            return new object[] { long.MinValue, 0, long.MaxValue };
        }

        private static object[] GenerateIntValues()
        {
            return new object[] { int.MinValue, 0, int.MaxValue };
        }

        private static object[] GenerateStringValues()
        {
            return new object[] { null, String.Empty };
        }

        private object[] GenerateArrayValues(Type elementType)
        {
            var list = new List<object> { null, Array.CreateInstance(elementType, 0) };
            foreach (var o in GenerateValues(elementType))
            {
                var array = Array.CreateInstance(elementType, 1);
                array.SetValue(o, 0);
                list.Add(array);
            }

            return list.ToArray();
        }

        private object[] GenerateArguments(Type[] parameters, int idx, IDictionary<Type, object[]> edges)
        {
            var arguments = new object[parameters.Length];
            for (var i = 0; i < parameters.Length; i++)
            {
                var p = parameters[i];
                if (!edges.ContainsKey(p))
                {
                    // unhandled type, just set to NULL for now
                    arguments[i] = null;
                }
                else
                {
                    var values = edges[p];
                    arguments[i] = values[idx % values.Length];
                }
            }
            return arguments;
        }

        //public void BeforeTest(ITest test)
        //{
        //}

        //public void AfterTest(ITest test)
        //{
        //}

        //public ActionTargets Targets { get; }
    }

}
