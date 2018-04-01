using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tangent.Tests
{
    public static class TestExtensions
    {
        public static T ShouldEqual<T>(this T actual, object expected)
        {
            Assert.AreEqual(expected, actual);
            return actual;
        }

        public static void ShouldBeTrue(this bool source)
        {
            Assert.IsTrue(source);
        }

        public static void AssertSameStringAs(this string actual, string expected)
        {
            if (!string.Equals(actual, expected))
            {
                var message = string.Format("Expected {0} but was {1}", expected, actual);
                throw new AssertionException(message);
            }
        }

    }
}
