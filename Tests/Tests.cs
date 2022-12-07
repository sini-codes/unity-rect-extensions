using NUnit.Framework;
using Sini.Unity;
using UnityEngine;

public class Tests
{
    [Test]
    public void ScaleBy_ScalesSizeOfRectangle()
    {
        Rect rect = new Rect(0, 0, 100, 100);
        Rect scaledRect = rect.ScaleBy(0.5f);

        Assert.AreEqual(new Vector2(50, 50), scaledRect.size);
    }


    [Test]
    public void ScaleBy_UsesScaleFactorsFromVector()
    {
        Rect rect = new Rect(0, 0, 100, 100);
        Rect scaledRect = rect.ScaleBy(new Vector2(0.5f, 2f));

        Assert.AreEqual(new Vector2(50, 200), scaledRect.size);
    }

    [Test]
    public void ScaleBy_ReturnsEmptyRectangleForZeroScale()
    {
        Rect rect = new Rect(0, 0, 100, 100);
        Rect scaledRect = rect.ScaleBy(0f);

        Assert.IsTrue(scaledRect.IsEmpty());
    }
    
    [Test]
    public void OffsetBy_OffsetsPositionOfRectangle()
    {
        Rect rect = new Rect(0, 0, 100, 100);
        Rect offsetRect = rect.OffsetBy(new Vector2(50, 50));

        Assert.AreEqual(new Vector2(50, 50), offsetRect.position);
        Assert.AreEqual(rect.size, offsetRect.size);
    }

    [Test]
    public void OffsetBy_LeavesSizeOfRectangleUnchanged()
    {
        Rect rect = new Rect(0, 0, 100, 100);
        Rect offsetRect = rect.OffsetBy(new Vector2(50, 50));

        Assert.AreEqual(rect.size, offsetRect.size);
    }

    [Test]
    public void OffsetBy_HandlesNegativeOffsets()
    {
        Rect rect = new Rect(0, 0, 100, 100);
        Rect offsetRect = rect.OffsetBy(new Vector2(-50, -50));

        Assert.AreEqual(new Vector2(-50, -50), offsetRect.position);
        Assert.AreEqual(rect.size, offsetRect.size);
    }

    [Test]
    public void OffsetBy_HandlesZeroOffset()
    {
        Rect rect = new Rect(0, 0, 100, 100);
        Rect offsetRect = rect.OffsetBy(Vector2.zero);

        Assert.AreEqual(rect, offsetRect);
        Assert.AreEqual(rect.size, offsetRect.size);
    }
    
    [Test]
    public void Below_ReturnsExpectedRect()
    {
        var rect = new Rect(1, 1, 5, 5);
        var other = new Rect(3, 3, 5, 5);
        var expected = new Rect(1, 10, 5, 5);

        var result = rect.Below(other, 2);
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Below_ZeroDistance_ReturnsExpectedRect()
    {
        var rect = new Rect(1, 1, 5, 5);
        var other = new Rect(3, 3, 5, 5);
        var expected = new Rect(1, 8, 5, 5);

        var result = rect.Below(other);
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Below_NegativeDistance_ReturnsExpectedRect()
    {
        var rect = new Rect(1, 1, 5, 5);
        var other = new Rect(3, 3, 5, 5);
        var expected = new Rect(1, 6, 5, 5);

        var result = rect.Below(other, -2);
        Assert.AreEqual(expected, result);
    }
    
    [Test]
    public void Above_ReturnsCorrectRect()
    {
        // Arrange
        var rect = new Rect(0, 0, 10, 10);
        var otherRect = new Rect(0, 0, 5, 5);
        var expected = new Rect(0, -5, 10, 5);

        // Act
        var result = rect.Above(otherRect);

        // Assert
        Assert.AreEqual(expected, result);
    }
    
    [Test]
    public void Above_DistanceZero_ReturnsCorrectRect()
    {
        var rect = new Rect(0, 0, 10, 10);
        var otherRect = new Rect(0, 0, 5, 5);
        var expected = new Rect(0, -5, 10, 5);

        var result = rect.Above(otherRect);

        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Above_DistanceNegative_ReturnsCorrectRect()
    {
        var rect = new Rect(0, 0, 10, 10);
        var otherRect = new Rect(0, 0, 5, 5);
        var expected = new Rect(0, -4, 10, 5);

        var result = rect.Above(otherRect, -1);

        Assert.AreEqual(expected, result);
    }
    
    [Test]
    public void RightOf_ShouldReturnCorrectRect_GivenValidInput()
    {
        var rect = new Rect(10, 20, 30, 40);
        var other = new Rect(50, 60, 70, 80);
        float distance = 5;

        var result = rect.RightOf(other, distance);

        Assert.That(result, Is.EqualTo(new Rect(125, 20, 30, 40)));
    }

    [Test]
    public void RightOf_ShouldReturnCorrectRect_WhenOtherRectIsEmpty()
    {
        var rect = new Rect(10, 20, 30, 40);
        var other = Rect.zero;
        float distance = 5;

        var result = rect.RightOf(other, distance);

        Assert.That(result, Is.EqualTo(new Rect(5, 20, 30, 40)));
    }

    [Test]
    public void RightOf_ShouldReturnCorrectRect_WhenDistanceIsZero()
    {
        var rect = new Rect(10, 20, 30, 40);
        var other = new Rect(50, 60, 70, 80);
        float distance = 0;

        var result = rect.RightOf(other, distance);

        Assert.That(result, Is.EqualTo(new Rect(120, 20, 30, 40)));
    }

    [Test]
    public void RightOf_ShouldReturnCorrectRect_WhenDistanceIsLessThanZero()
    {
        var rect = new Rect(10, 20, 30, 40);
        var other = new Rect(50, 60, 70, 80);
        float distance = -5;

        var result = rect.RightOf(other, distance);

        Assert.That(result, Is.EqualTo(new Rect(115, 20, 30, 40)));
    }
    
    [Test]
    public void LeftOf_ShouldReturnCorrectRect_GivenValidInput()
    {
        var rect = new Rect(10, 20, 30, 40);
        var other = new Rect(50, 60, 70, 80);
        float distance = 5;

        var result = rect.LeftOf(other, distance);

        Assert.That(result, Is.EqualTo(new Rect(15, 20, 30, 40)));
    }

    [Test]
    public void LeftOf_ShouldReturnCorrectRect_WhenOtherRectIsEmpty()
    {
        var rect = new Rect(10, 20, 30, 40);
        var other = Rect.zero;
        float distance = 5;

        var result = rect.LeftOf(other, distance);

        Assert.That(result, Is.EqualTo(new Rect(-35, 20, 30, 40)));
    }

    [Test]
    public void LeftOf_ShouldReturnCorrectRect_WhenDistanceIsZero()
    {
        var rect = new Rect(10, 20, 30, 40);
        var other = new Rect(50, 60, 70, 80);
        float distance = 0;

        var result = rect.LeftOf(other, distance);

        Assert.That(result, Is.EqualTo(new Rect(20, 20, 30, 40)));
    }

    [Test]
    public void LeftOf_ShouldReturnCorrectRect_WhenDistanceIsLessThanZero()
    {
        var rect = new Rect(10, 20, 30, 40);
        var other = new Rect(50, 60, 70, 80);
        float distance = -5;

        var result = rect.LeftOf(other, distance);

        Assert.That(result, Is.EqualTo(new Rect(25, 20, 30, 40)));
    }
    
    [Test]
    public void WithSize_ShouldReturnCorrectRect_GivenValidInput()
    {
        var rect = new Rect(10, 20, 30, 40);
        float width = 50;
        float height = 60;

        var result = rect.WithSize(width, height);

        Assert.That(result, Is.EqualTo(new Rect(10, 20, 50, 60)));
    }

    [Test]
    public void WithSize_ShouldReturnCorrectRect_WhenWidthIsZero()
    {
        var rect = new Rect(10, 20, 30, 40);
        float width = 0;
        float height = 60;

        var result = rect.WithSize(width, height);

        Assert.That(result, Is.EqualTo(new Rect(10, 20, 0, 60)));
    }

    [Test]
    public void WithSize_ShouldReturnCorrectRect_WhenHeightIsZero()
    {
        var rect = new Rect(10, 20, 30, 40);
        float width = 50;
        float height = 0;

        var result = rect.WithSize(width, height);

        Assert.That(result, Is.EqualTo(new Rect(10, 20, 50, 0)));
    }
    
    [Test]
    public void WithWidth_ShouldReturnCorrectRect_GivenValidInput()
    {
        var rect = new Rect(10, 20, 30, 40);
        float width = 50;

        var result = rect.WithWidth(width);

        Assert.That(result, Is.EqualTo(new Rect(10, 20, 50, 40)));
    }

    [Test]
    public void WithWidth_ShouldReturnCorrectRect_WhenWidthIsZero()
    {
        var rect = new Rect(10, 20, 30, 40);
        float width = 0;

        var result = rect.WithWidth(width);

        Assert.That(result, Is.EqualTo(new Rect(10, 20, 0, 40)));
    }
    
    [Test]
    public void WithHeight_ShouldReturnCorrectRect_GivenValidInput()
    {
        var rect = new Rect(10, 20, 30, 40);
        float height = 50;

        var result = rect.WithHeight(height);

        Assert.That(result, Is.EqualTo(new Rect(10, 20, 30, 50)));
    }

    [Test]
    public void WithHeight_ShouldReturnCorrectRect_WhenHeightIsZero()
    {
        var rect = new Rect(10, 20, 30, 40);
        float height = 0;

        var result = rect.WithHeight(height);

        Assert.That(result, Is.EqualTo(new Rect(10, 20, 30, 0)));
    }
    
    [Test]
    public void WithPosition_ShouldReturnCorrectRect_GivenValidInput()
    {
        var rect = new Rect(10, 20, 30, 40);
        float x = 50;
        float y = 60;

        var result = rect.WithPosition(x, y);

        Assert.That(result, Is.EqualTo(new Rect(50, 60, 30, 40)));
    }

    [Test]
    public void WithMargin_ShouldReturnCorrectRect_GivenValidInput()
    {
        // Arrange
        var rect = new Rect(10, 20, 30, 40);
        float left = 5;
        float top = 10;
        float right = 15;
        float bottom = 20;

        // Act
        var result = rect.WithMargin(left, top, right, bottom);

        // Assert
        Assert.That(result, Is.EqualTo(new Rect(15, 30, 10, 10)));
    }

    [Test]
    public void WithMargin_ShouldReturnCorrectRect_WhenMarginIsZero()
    {
        // Arrange
        var rect = new Rect(10, 20, 30, 40);
        float left = 0;
        float top = 0;
        float right = 0;
        float bottom = 0;

        // Act
        var result = rect.WithMargin(left, top, right, bottom);

        // Assert
        Assert.That(result, Is.EqualTo(new Rect(10, 20, 30, 40)));
    }

    [Test]
    public void WithMargin_ShouldReturnCorrectRect_WhenMarginIsNegative()
    {
        // Arrange
        var rect = new Rect(10, 20, 30, 40);
        float left = -5;
        float top = -10;
        float right = -15;
        float bottom = -20;

        // Act
        var result = rect.WithMargin(left, top, right, bottom);

        // Assert
        Assert.That(result, Is.EqualTo(new Rect(5, 10, 50, 70)));
    }

    [Test]
    public void WithPadding_ShouldReturnCorrectRect_GivenValidInput()
    {
        // Arrange
        var rect = new Rect(10, 20, 30, 40);
        float left = 5;
        float top = 10;
        float right = 15;
        float bottom = 20;

        // Act
        var result = rect.WithPadding(left, top, right, bottom);

        // Assert
        Assert.That(result, Is.EqualTo(new Rect(5, 10, 50, 70)));
    }

    [Test]
    public void WithPadding_ShouldReturnCorrectRect_WhenPaddingIsZero()
    {
        // Arrange
        var rect = new Rect(10, 20, 30, 40);
        float left = 0;
        float top = 0;
        float right = 0;
        float bottom = 0;

        // Act
        var result = rect.WithPadding(left, top, right, bottom);

        // Assert
        Assert.That(result, Is.EqualTo(new Rect(10, 20, 30, 40)));
    }
    
    [Test]
    public void WithPadding_ShouldReturnCorrectRect_WhenPaddingIsNegative()
    {
        // Arrange
        var rect = new Rect(10, 20, 30, 40);
        float left = -5;
        float top = -10;
        float right = -15;
        float bottom = -20;

        // Act
        var result = rect.WithPadding(left, top, right, bottom);

        // Assert
        Assert.That(result, Is.EqualTo(new Rect(15, 30, 10, 10)));
    }
    
}
