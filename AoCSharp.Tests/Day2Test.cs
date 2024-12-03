using AoCSharp;
using FluentAssertions;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AoCSharp.Tests;

[TestClass]
[TestSubject(typeof(Day2))]
public class Day2Test
{
    [DataRow("7 6 4 2 1", true)]
    [DataRow("1 2 7 8 9", false)]
    [DataRow("9 7 6 2 1", false)]
    [DataRow("1 3 2 4 5", false)]
    [DataRow("8 6 4 4 1", false)]
    [DataRow("1 3 6 7 9", true)]
    [TestMethod]
    public void ShouldDetectUnsafeReports(string report, bool isExpectedSafe)
    {
        int[] values = Day2.ExtractValues(report);
        bool actual = Day2.IsReportSafe(values);
        actual.Should().Be(isExpectedSafe);
    }
    
    [DataRow("7 6 4 2 1", true)]
    [DataRow("1 2 7 8 9", false)]
    [DataRow("9 7 6 2 1", false)]
    [DataRow("1 3 2 4 5", true)]
    [DataRow("8 6 4 4 1", true)]
    [DataRow("1 3 6 7 9", true)]
    [DataRow("65 64 65 68 71 74 77 77", false)]
    [DataRow("92 88 85 82 79 80 78 74", false)]
    [DataRow("85 88 86 85 82 81 80 73", false)]
    [DataRow("38 34 32 30 28 25 22", true)]
    [DataRow("85 88 86 85 82 81 80", true)]
    [TestMethod]
    public void ShouldDetectUnsafeReportsWithDampener(string report, bool isExpectedSafe)
    {
        int[] values = Day2.ExtractValues(report);
        bool actual = Day2.IsReportSafeWithDampener(values);
        actual.Should().Be(isExpectedSafe);
    }
}