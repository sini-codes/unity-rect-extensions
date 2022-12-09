using System.Runtime.CompilerServices;
using UnityEngine;

namespace Sini.Unity
{
    public static class RectExtensions
    {
        /// <summary>
        /// Determines whether the rectangle has zero size.
        /// </summary>
        /// <param name="rect">The rectangle to check.</param>
        /// <returns>True if the rectangle has zero size, false otherwise.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsEmpty(in this Rect rect)
        {
            return rect.width == 0 && rect.height == 0;
        }

        /// <summary>
        /// Scales the size of the rectangle by the given scale factors.
        /// </summary>
        /// <param name="rect">The rectangle to be scaled.</param>
        /// <param name="scale">The scale factors to use for scaling the rectangle.</param>
        /// <returns>A new rectangle with the same position as the original, but with scaled size.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Rect ScaleBy(in this Rect rect, float scale)
        {
            return new Rect(rect.x, rect.y, rect.width * scale, rect.height * scale);
        }

        /// <summary>
        /// Scales the size of the rectangle by the given scale factors.
        /// </summary>
        /// <param name="rect">The rectangle to be scaled.</param>
        /// <param name="scale">The scale factors to use for scaling the rectangle.</param>
        /// <returns>A new rectangle with the same position as the original, but with scaled size.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Rect ScaleBy(in this Rect rect, in Vector2 scale)
        {
            return new Rect(rect.x, rect.y, rect.width * scale.x, rect.height * scale.y);
        }

        /// <summary>
        /// Offsets the position of the rectangle by the given offset.
        /// </summary>
        /// <param name="rect">The rectangle to be offset.</param>
        /// <param name="offset">The offset to apply to the rectangle.</param>
        /// <returns>A new rectangle with the same size as the original, but with an offset position.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Rect OffsetBy(in this Rect rect, in Vector2 offset)
        {
            return new Rect(rect.x + offset.x, rect.y + offset.y, rect.width, rect.height);
        }
        
        /// <summary>
        /// Places the specified rect above the rect on which the method is called, with the option to add additional distance.
        /// </summary>
        /// <param name="rect">The rect on which the method is called.</param>
        /// <param name="otherRect">The rect to place above the rect on which the method is called.</param>
        /// <param name="distance">The additional distance to move the resulting rect.</param>
        /// <returns>A new rect with the same width and height as the specified rect and positioned above the rect on which the method is called, with the option to add additional distance.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Rect Above(this in Rect rect, in Rect otherRect, float distance = 0)
        {
            return new Rect(rect.x, rect.y - otherRect.height - distance, rect.width, otherRect.height);
        }

        /// <summary>
        /// Place a Rect below another Rect with an optional distance.
        /// </summary>
        /// <param name="rect">The Rect to move.</param>
        /// <param name="other">The Rect to use as a reference point.</param>
        /// <param name="distance">The optional distance to use between the two Rects. Default is 0.</param>
        /// <returns>A new Rect with the adjusted position.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Rect Below(in this Rect rect, in Rect other, float distance = 0)
        {
            return new Rect(rect.x, other.yMax + distance, other.width, other.height);
        }
        
        /// <summary>
        /// Returns a new <see cref="Rect"/> that is positioned to the left of the specified other <see cref="Rect"/>,
        /// with the specified distance between them.
        /// </summary>
        /// <param name="rect">The original <see cref="Rect"/> to use as a reference.</param>
        /// <param name="other">The other <see cref="Rect"/> to position the new <see cref="Rect"/> relative to.</param>
        /// <param name="distance">The distance between the two <see cref="Rect"/>s. Default is 0.</param>
        /// <returns>A new <see cref="Rect"/> that is positioned to the left of the other <see cref="Rect"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Rect LeftOf(in this Rect rect, in Rect other, float distance = 0)
        {
            return new Rect(other.x - rect.width - distance, rect.y, rect.width, rect.height);
        }
        
        /// <summary>
        /// Returns a new <see cref="Rect"/> that is positioned to the right of the specified other <see cref="Rect"/>,
        /// with the specified distance between them.
        /// </summary>
        /// <param name="rect">The original <see cref="Rect"/> to use as a reference.</param>
        /// <param name="other">The other <see cref="Rect"/> to position the new <see cref="Rect"/> relative to.</param>
        /// <param name="distance">The distance between the two <see cref="Rect"/>s. Default is 0.</param>
        /// <returns>A new <see cref="Rect"/> that is positioned to the right of the other <see cref="Rect"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Rect RightOf(in this Rect rect, in Rect other, float distance = 0)
        {
            return new Rect(other.x + other.width + distance, rect.y, rect.width, rect.height);
        }
        
        /// <summary>
        /// Returns a new <see cref="Rect"/> with the same position as the original <see cref="Rect"/>, but with the specified width and height.
        /// </summary>
        /// <param name="source">The original <see cref="Rect"/> to use as a reference.</param>
        /// <param name="width">The width of the new <see cref="Rect"/>.</param>
        /// <param name="height">The height of the new <see cref="Rect"/>.</param>
        /// <returns>A new <see cref="Rect"/> with the same position as the original <see cref="Rect"/>, but with the specified width and height.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Rect WithSize(in this Rect source, float width, float height)
        {
            return new Rect(source.x, source.y, width, height);
        }

        /// <summary>
        /// Returns a new <see cref="Rect"/> with the same position and height as the original <see cref="Rect"/>, but with the specified width.
        /// </summary>
        /// <param name="source">The original <see cref="Rect"/> to use as a reference.</param>
        /// <param name="width">The width of the new <see cref="Rect"/>.</param>
        /// <returns>A new <see cref="Rect"/> with the same position and height as the original <see cref="Rect"/>, but with the specified width.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Rect WithWidth(in this Rect source, float width)
        {
            return new Rect(source.x, source.y, width, source.height);
        }
        
        /// <summary>
        /// Returns a new <see cref="Rect"/> with the same position and width as the original <see cref="Rect"/>, but with the specified height.
        /// </summary>
        /// <param name="source">The original <see cref="Rect"/> to use as a reference.</param>
        /// <param name="height">The height of the new <see cref="Rect"/>.</param>
        /// <returns>A new <see cref="Rect"/> with the same position and width as the original <see cref="Rect"/>, but with the specified height.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Rect WithHeight(in this Rect source, float height)
        {
            return new Rect(source.x, source.y, source.width, height);
        }
        
        /// <summary>
        /// Returns a new <see cref="Rect"/> with the same width and height as the original <see cref="Rect"/>, but with the specified position.
        /// </summary>
        /// <param name="source">The original <see cref="Rect"/> to use as a reference.</param>
        /// <param name="x">The x-coordinate of the new <see cref="Rect"/>.</param>
        /// <param name="y">The y-coordinate of the new <see cref="Rect"/>.</param>
        /// <returns>A new <see cref="Rect"/> with the same width and height as the original <see cref="Rect"/>, but with the specified position.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Rect WithPosition(in this Rect source, float x, float y)
        {
            return new Rect(x, y, source.width, source.height);
        }
        
        /// <summary>
        /// Returns a new rectangle with the same size as the original but with its position set to the specified position.
        /// </summary>
        /// <param name="rect">The rectangle to modify.</param>
        /// <param name="position">The new position for the rectangle.</param>
        /// <returns>A new rectangle with the same size as the original but with its position set to the specified position.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Rect WithPosition(this in Rect rect, in Vector2 position)
        {
            return new Rect(position.x, position.y, rect.width, rect.height);
        }
        
        /// <summary>
        /// Returns a new <see cref="Rect"/> that is positioned with the specified amount of margin on the specified sides.
        /// </summary>
        /// <param name="source">The original <see cref="Rect"/> to use as a reference.</param>
        /// <param name="left">The amount of margin to add to the left side of the <see cref="Rect"/>.</param>
        /// <param name="top">The amount of margin to add to the top side of the <see cref="Rect"/>.</param>
        /// <param name="right">The amount of margin to add to the right side of the <see cref="Rect"/>.</param>
        /// <param name="bottom">The amount of margin to add to the bottom side of the <see cref="Rect"/>.</param>
        /// <returns>A new <see cref="Rect"/> with the specified margin.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Rect WithMargin(in this Rect source, float left, float top, float right, float bottom)
        {
            return new Rect(source.x + left, source.y + top, source.width - left - right, source.height - top - bottom);
        }
        
        /// <summary>
        /// Returns a new <see cref="Rect"/> that is positioned with the specified amount of margin on all sides.
        /// </summary>
        /// <param name="source">The original <see cref="Rect"/> to use as a reference.</param>
        /// <param name="margin">The amount of margin to add to all sides of the <see cref="Rect"/>.</param>
        /// <returns>A new <see cref="Rect"/> with the specified margin.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Rect WithMargin(in this Rect source, float margin)
        {
            return source.WithMargin(margin,margin,margin,margin);
        }
        
        /// <summary>
        /// Returns a new <see cref="Rect"/> that is padded with the specified amount of padding on the specified sides.
        /// </summary>
        /// <param name="source">The original <see cref="Rect"/> to use as a reference.</param>
        /// <param name="left">The amount of padding to add to the left side of the <see cref="Rect"/>.</param>
        /// <param name="top">The amount of padding to add to the top side of the <see cref="Rect"/>.</param>
        /// <param name="right">The amount of padding to add to the right side of the <see cref="Rect"/>.</param>
        /// <param name="bottom">The amount of padding to add to the bottom side of the <see cref="Rect"/>.</param>
        /// <returns>A new <see cref="Rect"/> with the specified padding.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Rect WithPadding(in this Rect source, float left, float top, float right, float bottom)
        {
            return source.WithMargin(-left, -top, -right, -bottom);
        }
        
        /// <summary>
        /// Returns a new <see cref="Rect"/> that is padded with the specified amount of padding on all sides.
        /// </summary>
        /// <param name="source">The original <see cref="Rect"/> to use as a reference.</param>
        /// <param name="padding">The amount of padding to add to all sides of the <see cref="Rect"/>.</param>
        /// <returns>A new <see cref="Rect"/> with the specified padding.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Rect WithPadding(in this Rect source, float padding)
        {
            return source.WithMargin(-padding, -padding, -padding, -padding);
        }
        
        /// <summary>
        /// Returns the top half of the given <see cref="Rect"/>.
        /// </summary>
        /// <param name="rect">The original <see cref="Rect"/> to use as a reference.</param>
        /// <returns>A new <see cref="Rect"/> with the same position and width as the original <see cref="Rect"/>, but with a height that is half the height of the original <see cref="Rect"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Rect TopHalf(in this Rect rect)
        {
            return new Rect(rect.x, rect.y, rect.width, rect.height / 2);
        }
        
        /// <summary>
        /// Returns the bottom half of the given <see cref="Rect"/>.
        /// </summary>
        /// <param name="rect">The original <see cref="Rect"/> to use as a reference.</param>
        /// <returns>A new <see cref="Rect"/> with the same width as the original <see cref="Rect"/>, but with a position and height that represent the bottom half of the original <see cref="Rect"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Rect BottomHalf(in this Rect rect)
        {
            return new Rect(rect.x, rect.y + rect.height / 2, rect.width, rect.height / 2);
        }

        /// <summary>
        /// Returns the left half of the given <see cref="Rect"/>.
        /// </summary>
        /// <param name="rect">The original <see cref="Rect"/> to use as a reference.</param>
        /// <returns>A new <see cref="Rect"/> with the same height as the original <see cref="Rect"/>, but with a position and width that represent the left half of the original <see cref="Rect"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Rect LeftHalf(in this Rect rect)
        {
            return new Rect(rect.x, rect.y, rect.width / 2, rect.height);
        }

        /// <summary>
        /// Returns the right half of the given <see cref="Rect"/>.
        /// </summary>
        /// <param name="rect">The original <see cref="Rect"/> to use as a reference.</param>
        /// <returns>A new <see cref="Rect"/> with the same height as the original <see cref="Rect"/>, but with a position and width that represent the right half of the original <see cref="Rect"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Rect RightHalf(in this Rect rect)
        {
            return new Rect(rect.x + rect.width / 2, rect.y, rect.width / 2, rect.height);
        }
        
        /// <summary>
        /// Centers the specified rectangle inside the given other rectangle by aligning their centers.
        /// </summary>
        /// <param name="rect">The rectangle to center.</param>
        /// <param name="other">The rectangle to center the first rectangle inside of.</param>
        /// <returns>A new rectangle with the same size as the original rectangle, but with its position adjusted so that it is centered inside the other rectangle with their centers aligned.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Rect CenterInside(this in Rect rect, in Rect other)
        {
            var center = new Vector2(
                other.x + other.width / 2 - rect.width / 2,
                other.y + other.height / 2 - rect.height / 2
            );

            return rect.WithPosition(center);
        }
        
        /// <summary>
        /// Returns a new Rect with the same y, width, and height as the first Rect, but with the x value centered inside the second Rect.
        /// </summary>
        /// <param name="rect">The first Rect.</param>
        /// <param name="other">The second Rect to center the first Rect inside.</param>
        /// <returns>A new Rect with the same y, width, and height as the first Rect, but with the x value centered inside the second Rect.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Rect CenterXInside(in this Rect rect, in Rect other)
        {
            var x = other.x + (other.width - rect.width) / 2;
            return new Rect(x, rect.y, rect.width, rect.height);
        }
        
        /// <summary>
        /// Returns a new Rect with the same x, width, and height as the first Rect, but with the y value centered inside the second Rect.
        /// </summary>
        /// <param name="rect">The first Rect.</param>
        /// <param name="other">The second Rect to center the first Rect inside.</param>
        /// <returns>A new Rect with the same x, width, and height as the first Rect, but with the y value centered inside the second Rect.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Rect CenterYInside(in this Rect rect, in Rect other)
        {
            var y = other.y + (other.height - rect.height) / 2;
            return new Rect(rect.x, y, rect.width, rect.height);
        }
        
        /// <summary>
        /// Positions the specified rectangle at the same height as the given other rectangle.
        /// </summary>
        /// <param name="rect">The rectangle to position.</param>
        /// <param name="other">The rectangle to use as a reference point for the height.</param>
        /// <returns>A new rectangle with the same size as the original rectangle, but with its y position set to the y position of the other rectangle.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Rect WithYOf(this in Rect rect, in Rect other)
        {
            return rect.WithPosition(new Vector2(rect.x, other.y));
        }
        
        /// <summary>
        /// Returns a new Rect with the same y, width, and height as the first Rect, but with the x value of the second Rect.
        /// </summary>
        /// <param name="rect">The first Rect.</param>
        /// <param name="other">The second Rect.</param>
        /// <returns>A new Rect with the x value of the second Rect and the same y, width, and height as the first Rect.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Rect WithXOf(in this Rect rect, in Rect other)
        {
            return new Rect(other.x, rect.y, rect.width, rect.height);
        }
        
        /// <summary>
        /// Returns a new Rect with the same x, y, and width as the first Rect, but with the height value of the second Rect.
        /// </summary>
        /// <param name="rect">The first Rect.</param>
        /// <param name="other">The second Rect.</param>
        /// <returns>A new Rect with the height value of the second Rect and the same x, y, and width as the first Rect.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Rect WithHeightOf(in this Rect rect, in Rect other)
        {
            return new Rect(rect.x, rect.y, rect.width, other.height);
        }

        /// <summary>
        /// Returns a new Rect with the same x, y, and height as the first Rect, but with the width value of the second Rect.
        /// </summary>
        /// <param name="rect">The first Rect.</param>
        /// <param name="other">The second Rect.</param>
        /// <returns>A new Rect with the width value of the second Rect and the same x, y, and height as the first Rect.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Rect WithWidthOf(in this Rect rect, in Rect other)
        {
            return new Rect(rect.x, rect.y, other.width, rect.height);
        }
        
     
        
        
        
    }
}