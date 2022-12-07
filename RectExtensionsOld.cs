using UnityEngine;
using System.Linq;

namespace Sini.Unity
{
    public static class RectExtensionsOld
    {

        public static Rect AlignTopRight(Rect source, Rect target)
        {
            return new Rect(target.xMax - source.width, target.y, source.width, source.height);
        }

        public static Rect AlignHorisonallyByCenter(Rect source, Rect target)
        {
            var y = target.y + (target.height - source.height) / 2;

            return new Rect(source.x, y, source.width, source.height);
        }

        public static Rect AlignVerticallyByCenter(Rect source, Rect target)
        {
            var x = target.x + (target.width - source.width) / 2;
            return new Rect(x, source.y, source.width, source.height);
        }

        public static Rect Align(Rect source, Rect target)
        {
            return new Rect(target.x, target.y, source.width, source.height);
        }

        public static Rect AlignAndScale(Rect source, Rect target)
        {
            return new Rect(target.x, target.y, target.width, target.height);
        }

        public static Rect AlignHorisontally(Rect source, Rect target)
        {
            return new Rect(source.x, target.y, source.width, source.height);
        }

        public static Rect AlignVertically(Rect source, Rect target)
        {
            return new Rect(target.x, source.y, source.width, source.height);
        }

        public static Rect CenterInsideOf(Rect source, Rect target)
        {
            var y = target.y + (target.height - source.height) / 2;
            var x = target.x + (target.width - source.width) / 2;
            return new Rect(x, y, source.width, source.height);
        }

        public static Rect LeftHalf(Rect source)
        {
            return new Rect(source.x, source.y, source.width / 2, source.height);
        }

        public static Rect RightHalf(Rect source)
        {
            return new Rect(source.x + source.width / 2, source.y, source.width / 2, source.height);
        }

        public static Rect TopHalf(Rect source)
        {
            return new Rect(source.x, source.y, source.width, source.height / 2);
        }

        public static Rect BottomHalf(Rect source)
        {
            return new Rect(source.x, source.y + source.height / 2, source.width, source.height / 2);
        }
        public static Rect Clip(Rect source, Rect target)
        {
            var x = source.x;
            if (source.x < target.x) x = target.x;
            if (source.x > target.xMax) x = target.xMax;

            var y = source.y;
            if (source.y < target.y) y = target.y;
            if (source.y > target.yMax) y = target.yMax;

            var width = source.width;
            if (x + source.width > target.xMax) width = target.xMax - source.x;

            var height = source.height;
            if (y + source.height > target.yMax) height = target.yMax - source.y;

            return new Rect(x, y, width, height);
        }

        public static Rect InnerAlignWithBottomRight(Rect source, Rect target)
        {
            return new Rect(target.xMax - source.width, target.yMax - source.height, source.width, source.height);
        }

        public static Rect InnerAlignWithCenterRight(Rect source, Rect target)
        {
            return AlignHorisonallyByCenter(InnerAlignWithBottomRight(source, target), target);
        }

        public static Rect InnerAlignWithCenterLeft(Rect source, Rect target)
        {
            return AlignHorisonallyByCenter(InnerAlignWithBottomLeft(source, target), target);
        }

        public static Rect InnerAlignWithBottomLeft(Rect source, Rect target)
        {
            return new Rect(target.x, target.yMax - source.height, source.width, source.height);
        }

        public static Rect InnerAlignWithUpperRight(Rect source, Rect target)
        {
            return new Rect(target.xMax - source.width, target.y, source.width, source.height);
        }

        public static Rect InnerAlignWithBottomCenter(Rect source, Rect target)
        {
            var rect = AlignVerticallyByCenter(source, target);
            rect.y = target.yMax - rect.height;
            return rect;
        }

        public static Rect LeftOf(Rect source, Rect target)
        {
            return new Rect(target.x - source.width, source.y, source.width, source.height);
        }

        public static Rect Above(Rect source, Rect target)
        {
            return new Rect(source.x, target.y - source.height, source.width, source.height);
        }

        public static Rect AboveAll(Rect source, Rect target, int i)
        {
            return new Rect(source.x, target.y - source.height * i, source.width, source.height);
        }

        public static Rect Cover(Rect source, params Rect[] targets)
        {
            var x = targets.Min(t => t.x);
            var y = targets.Min(t => t.y);
            var width = targets.Max(t => t.xMax - x);
            var height = targets.Max(t => t.yMax - y);
            return new Rect(x, y, width, height);
        }

        public static Rect StretchedVerticallyAlong(Rect source, Rect target)
        {
            return new Rect(source.x, source.y, source.width, target.yMax - source.y);
        }

        public static Rect AddHeight(Rect source, int height)
        {
            return new Rect(source.x, source.y, source.width, source.height + height);
        }
        public static Rect AddWidth(Rect source, int width)
        {
            return new Rect(source.x, source.y, source.width + width, source.height);
        }


    }
}
