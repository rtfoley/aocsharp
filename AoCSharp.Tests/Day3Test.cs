using AoCSharp;
using FluentAssertions;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AoCSharp.Tests;

[TestClass]
[TestSubject(typeof(Day3))]
public class Day3Test
{

    [TestMethod]
    public void ShouldGetCorrectTotal()
    {
        string input = "xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))";
        int actual = Day3.GetTotal(input);
        actual.Should().Be(161);
    }
}