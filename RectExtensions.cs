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
        
    }
}