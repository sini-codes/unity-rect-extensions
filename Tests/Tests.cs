using System;
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
    
    [Test]
    public void TopHalf_ReturnsCorrectRect()
    {
        // Arrange
        Rect rect = new Rect(10, 10, 100, 100);

        // Act
        Rect topHalf = rect.TopHalf();

        // Assert
        Assert.AreEqual(10, topHalf.x);
        Assert.AreEqual(10, topHalf.y);
        Assert.AreEqual(100, topHalf.width);
        Assert.AreEqual(50, topHalf.height);
    }
    
    [Test]
    public void TopHalf_EmptyRect_ReturnsEmptyRect()
    {
        // Arrange
        Rect rect = new Rect();

        // Act
        Rect topHalf = rect.TopHalf();

        // Assert
        Assert.AreEqual(0, topHalf.x);
        Assert.AreEqual(0, topHalf.y);
        Assert.AreEqual(0, topHalf.width);
        Assert.AreEqual(0, topHalf.height);
    }
    
    [Test]
    public void BottomHalf_ReturnsCorrectRect()
    {
        // Arrange
        Rect rect = new Rect(10, 10, 100, 100);

        // Act
        Rect bottomHalf = rect.BottomHalf();

        // Assert
        Assert.AreEqual(10, bottomHalf.x);
        Assert.AreEqual(60, bottomHalf.y);
        Assert.AreEqual(100, bottomHalf.width);
        Assert.AreEqual(50, bottomHalf.height);
    }
    
    [Test]
    public void LeftHalf_ReturnsCorrectRect()
    {
        // Arrange
        Rect rect = new Rect(10, 10, 100, 100);

        // Act
        Rect leftHalf = rect.LeftHalf();

        // Assert
        Assert.AreEqual(10, leftHalf.x);
        Assert.AreEqual(10, leftHalf.y);
        Assert.AreEqual(50, leftHalf.width);
        Assert.AreEqual(100, leftHalf.height);
    }

    [Test]
    public void RightHalf_ReturnsCorrectRect()
    {
        // Arrange
        Rect rect = new Rect(10, 10, 100, 100);

        // Act
        Rect rightHalf = rect.RightHalf();

        // Assert
        Assert.AreEqual(60, rightHalf.x);
        Assert.AreEqual(10, rightHalf.y);
        Assert.AreEqual(50, rightHalf.width);
        Assert.AreEqual(100, rightHalf.height);
    }
    
    [Test]
    public void LeftHalf_EmptyRect_ReturnsEmptyRect()
    {
        // Create a new rect with a width of 100 and a height of 50.
        Rect rect = new Rect(0, 0, 100, 50);

        // Call the LeftHalf method on the rect.
        Rect leftHalf = rect.LeftHalf();

        // Assert that the left half has the expected values.
        Assert.AreEqual(0, leftHalf.x);
        Assert.AreEqual(0, leftHalf.y);
        Assert.AreEqual(50, leftHalf.width);
        Assert.AreEqual(50, leftHalf.height);
    }

    [Test]
    public void RightHalf_EmptyRect_ReturnsEmptyRect()
    {
        // Create a new rect with a width of 100 and a height of 50.
        Rect rect = new Rect(0, 0, 100, 50);

        // Call the RightHalf method on the rect.
        Rect rightHalf = rect.RightHalf();

        // Assert that the right half has the expected values.
        Assert.AreEqual(50, rightHalf.x);
        Assert.AreEqual(0, rightHalf.y);
        Assert.AreEqual(50, rightHalf.width);
        Assert.AreEqual(50, rightHalf.height);
    }

    [Test]
    public void BottomHalf_EmptyRect_ReturnsEmptyRect()
    {
        // Create a new rect with a width of 100 and a height of 50.
        Rect rect = new Rect(0, 0, 100, 50);

        // Call the BottomHalf method on the rect.
        Rect bottomHalf = rect.BottomHalf();

        // Assert that the bottom half has the expected values.
        Assert.AreEqual(0, bottomHalf.x);
        Assert.AreEqual(25, bottomHalf.y);
        Assert.AreEqual(100, bottomHalf.width);
        Assert.AreEqual(25, bottomHalf.height);
    }
    
    [Test]
    public void CenterInside_ShouldCenterRectInsideOtherRectWithCentersAligned()
    {
        var outer = new Rect(0, 0, 100, 100);
        var inner = new Rect(0, 0, 10, 10);

        var centered = inner.CenterInside(outer);

        Assert.AreEqual(45, centered.x);
        Assert.AreEqual(45, centered.y);
        Assert.AreEqual(10, centered.width);
        Assert.AreEqual(10, centered.height);
    }

    [Test]
    public void WithPosition_ShouldSetPositionOfRect()
    {
        var rect = new Rect(0, 0, 100, 100);
        var position = new Vector2(50, 50);

        var newRect = rect.WithPosition(position);

        Assert.AreEqual(50, newRect.x);
        Assert.AreEqual(50, newRect.y);
        Assert.AreEqual(100, newRect.width);
        Assert.AreEqual(100, newRect.height);
    }
    
    [Test]
    public void WithYOf_ReturnsExpectedResult()
    {
        var rect = new Rect(0, 0, 100, 100);
        var other = new Rect(0, 50, 100, 100);

        var newRect = rect.WithYOf(other);

        Assert.AreEqual(0, newRect.x);
        Assert.AreEqual(50, newRect.y);
        Assert.AreEqual(100, newRect.width);
        Assert.AreEqual(100, newRect.height);
    }
    
    [Test]
    public void WithHeightOf_ReturnsExpectedResult()
    {
        var rect = new Rect(0, 0, 10, 20);
        var other = new Rect(0, 0, 5, 10);

        var result = rect.WithHeightOf(other);

        Assert.AreEqual(new Rect(0, 0, 10, 10), result);
    }

    [Test]
    public void WithXOf_ReturnsExpectedResult()
    {
        var rect = new Rect(0, 0, 10, 20);
        var other = new Rect(5, 0, 5, 10);

        var result = rect.WithXOf(other);

        Assert.AreEqual(new Rect(5, 0, 10, 20), result);
    }
    
    [Test]
    public void WithWidthOf_ReturnsExpectedResult()
    {
        var rect = new Rect(0, 0, 10, 20);
        var other = new Rect(0, 0, 5, 10);

        var result = rect.WithWidthOf(other);

        Assert.AreEqual(new Rect(0, 0, 5, 20), result);
    }
    
    [Test]
    public void CenterYInside_ReturnsExpectedResult()
    {
        var rect = new Rect(0, 0, 10, 10);
        var other = new Rect(0, 0, 20, 20);

        var result = rect.CenterYInside(other);

        Assert.AreEqual(new Rect(0, 5, 10, 10), result);
    }
    
    [Test]
    public void CenterXInside_ReturnsExpectedResult()
    {
        var rect = new Rect(0, 0, 10, 10);
        var other = new Rect(0, 0, 20, 20);

        var result = rect.CenterXInside(other);

        Assert.AreEqual(new Rect(5, 0, 10, 10), result);
    }
    
    [Test]
    public void Cell_ReturnsCorrectRect()
    {
        var rect = new Rect(0, 0, 100, 100);
        var columns = 10;
        var rows = 10;
        var x = 4;
        var y = 4;

        var result = rect.Cell(columns, rows, x, y);
        // Assert that the result matches the expected values
        Assert.AreEqual(new Rect(40,40,10,10), result);
    }

    [Test]
    public void Cell_WithColumnsLessThanOrEqualToZero()
    {
        var rect = new Rect(0, 0, 100, 100);
        var columns = 0;
        var rows = 10;
        var x = 5;
        var y = 5;

        // Assert that the correct exception is thrown when columns is <= 0
        Assert.Throws<ArgumentException>(() => rect.Cell(columns, rows, x, y));
    }

    [Test]
    public void Cell_WithRowsLessThanOrEqualToZero()
    {
        var rect = new Rect(0, 0, 100, 100);
        var columns = 10;
        var rows = 0;
        var x = 5;
        var y = 5;

        // Assert that the correct exception is thrown when rows is <= 0
        Assert.Throws<ArgumentException>(() => rect.Cell(columns, rows, x, y));
    }

    [Test]
    public void Cell_WithXOutOfRange()
    {
        var rect = new Rect(0, 0, 100, 100);
        var columns = 10;
        var rows = 10;
        var x = 11; // x is out of range because it is >= columns
        var y = 5;

        // Assert that the correct exception is thrown when x is not within the range 0 < x < columns
        Assert.Throws<ArgumentException>(() => rect.Cell(columns, rows, x, y));
    }

    [Test]
    public void Cell_WithYOutOfRange()
    {
        var rect = new Rect(0, 0, 100, 100);
        var columns = 10;
        var rows = 10;
        var x = 5;
        var y = 11; // y is out of range because it is >= rows

        // Assert that the correct exception is thrown when y is not within the range 0 < y < rows
        Assert.Throws<ArgumentException>(() => rect.Cell(columns, rows, x, y));
    }
}
