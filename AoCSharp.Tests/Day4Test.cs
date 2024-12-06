using AoCSharp;
using FluentAssertions;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AoCSharp.Tests;

[TestClass]
[TestSubject(typeof(Day4))]
public class Day4Test
{

    [TestMethod]
    public void ShouldFindCorrectNumberOfWords()
    {
        string[] testInput = new[]
        {
            "MMMSXXMASM",
            "MSAMXMSMSA",
            "AMXSXMAAMM",
            "MSAMASMSMX",
            "XMASAMXAMM",
            "XXAMMXXAMA",
            "SMSMSASXSS",
            "SAXAMASAAA",
            "MAMMMXMMMM",
            "MXMXAXMASX",
        };
        
        int actual = Day4.GetWordCount(testInput);
        actual.Should().Be(18);
    }
    
    [TestMethod]
    public void ShouldFindCorrectNumberOfXs()
    {
        string[] testInput = new[]
        {
            "MMMSXXMASM",
            "MSAMXMSMSA",
            "AMXSXMAAMM",
            "MSAMASMSMX",
            "XMASAMXAMM",
            "XXAMMXXAMA",
            "SMSMSASXSS",
            "SAXAMASAAA",
            "MAMMMXMMMM",
            "MXMXAXMASX",
        };
        
        int actual = Day4.GetXCount(testInput);
        actual.Should().Be(9);
    }
}