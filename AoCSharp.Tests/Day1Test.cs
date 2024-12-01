using System.Collections.Generic;
using AoCSharp;
using FluentAssertions;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AoCSharp.Tests;

[TestClass]
[TestSubject(typeof(Day1))]
public class Day1Test
{

    [TestMethod]
    public void ShouldReturnCorrectDistance()
    {
        List<int> first = new List<int> { 3, 4, 2, 1, 3, 3 };
        List<int> second = new List<int> { 4, 3, 5, 3, 9, 3 };
        int result = Day1.GetDistance(first, second);
        result.Should().Be(11);
    }
    
    [TestMethod]
    public void ShouldReturnCorrectSimilarity()
    {
        List<int> first = new List<int> { 3, 4, 2, 1, 3, 3 };
        List<int> second = new List<int> { 4, 3, 5, 3, 9, 3 };
        int result = Day1.GetSimilarityScore(first, second);
        result.Should().Be(31);
    }
}