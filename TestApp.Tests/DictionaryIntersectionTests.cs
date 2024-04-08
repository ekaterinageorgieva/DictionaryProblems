using System.Collections.Generic;

using NUnit.Framework;

namespace TestApp.Tests;

[TestFixture]
public class DictionaryIntersectionTests
{
    [Test]
    public void Test_Intersect_TwoEmptyDictionaries_ReturnsEmptyDictionary()
    {
        // Arrange
        Dictionary<string, int> dict1 = new();
        Dictionary<string, int> dict2 = new();

        // Act 
        Dictionary<string, int> result = DictionaryIntersection.Intersect(dict1, dict2);

        // Assert
        Assert.That(result, Has.Count.EqualTo(0));
       
    }

    [Test]
    public void Test_Intersect_OneEmptyDictionaryAndOneNonEmptyDictionary_ReturnsEmptyDictionary()
    {
        // Arrange
        Dictionary<string, int> dict1 = new();
        Dictionary<string, int> dict2 = new()
        {
            {"one", 1 },
            {"two", 2 }
        };

        // Act 
        Dictionary<string, int> result = DictionaryIntersection.Intersect(dict1, dict2);

        // Assert
        Assert.That(result, Has.Count.EqualTo(0));

    }

    [Test]
    public void Test_Intersect_TwoNonEmptyDictionariesWithNoCommonKeys_ReturnsEmptyDictionary()
    {
        // Arrange
        Dictionary<string, int> dict1 = new()
        {
            {"one", 1 },
            {"two", 2 }
        };
        Dictionary<string, int> dict2 = new()
        {
            {"three", 3 },
            {"four", 4 }
        };

        // Act 
        Dictionary<string, int> result = DictionaryIntersection.Intersect(dict1, dict2);

        // Assert
        Assert.That(result, Has.Count.EqualTo(0));
    }

    [Test]
    public void Test_Intersect_TwoNonEmptyDictionariesWithCommonKeysAndValues_ReturnsIntersectionDictionary()
    {
        // Arrange
        Dictionary<string, int> dict1 = new()
        {
            {"two", 2},
            {"three", 3 },
            {"four", 4 }
        };
        Dictionary<string, int> dict2 = new()
        {
            {"three", 3 },
            {"four", 4 }
        };

        // Act 
        Dictionary<string, int> result = DictionaryIntersection.Intersect(dict1, dict2);

        // Assert
        Assert.That(result, Has.Count.EqualTo(2));
    }

    [Test]
    public void Test_Intersect_TwoNonEmptyDictionariesWithCommonKeysAndDifferentValues_ReturnsEmptyDictionary()
    {
        // Arrange
        Dictionary<string, int> dict1 = new()
        {
            {"three", 3 },
            {"four", 4 }
        };
        Dictionary<string, int> dict2 = new()
        {
            {"three", 1 },
            {"four", 9 }
        };

        // Act 
        Dictionary<string, int> result = DictionaryIntersection.Intersect(dict1, dict2);

        // Assert
        Assert.That(result, Has.Count.EqualTo(0));
    }
}
