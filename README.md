# Unity Rect Extensions
Fluent API for Unity Rect layouting for building maintainable editor UI.

# Installation

### Using Koinonia

`install nitreo/unity-rect-extensions`

### Manual

Download Zip or Clone repo inside Assets folder.

# Usage

Given some rects, you can create new rects by means of supplied extensions methods.
Keep in mind, that each operation returns a new rect without modifying the original.

```
var a = new Rect(0,0,50,50); # Rect 1
var b = new Rect(0,0,10,10) # Rect 2
        .CenterInsideOf(a); # Rect 3
```

This code gives you 2 rects (a and b) where b is centered inside of a.

# Api

* Below(this Rect source, Rect belowSource)
* RightOf(this Rect source, Rect target)
* WithSize(this Rect source, float width, float height)
* WithWidth(this Rect source, float width)
* WithHeight(this Rect source, float height)
* Pad(this Rect source, float left, float top, float right, float bottom)
* PadSides(this Rect source, float padding)
* AlignTopRight(this Rect source, Rect target)
* AlignHorisonallyByCenter(this Rect source, Rect target)
* AlignVerticallyByCenter(this Rect source, Rect target)
* Translate(this Rect source, float x, float y)
* WithOrigin(this Rect source, float x, float y)
* Align(this Rect source, Rect target)
* AlignAndScale(this Rect source, Rect target)
* AlignHorisontally(this Rect source, Rect target)
* AlignVertically(this Rect source, Rect target)
* CenterInsideOf(this Rect source, Rect target)
* LeftHalf(this Rect source)
* RightHalf(this Rect source)
* TopHalf(this Rect source)
* BottomHalf(this Rect source)
* Clip(this Rect source, Rect target)
* InnerAlignWithBottomRight(this Rect source, Rect target)
* InnerAlignWithCenterRight(this Rect source, Rect target)
* InnerAlignWithCenterLeft(this Rect source, Rect target)
* InnerAlignWithBottomLeft(this Rect source, Rect target)
* InnerAlignWithUpperRight(this Rect source, Rect target)
* InnerAlignWithBottomCenter(this Rect source, Rect target)
* LeftOf(this Rect source, Rect target)
* Above(this Rect source, Rect target)
* AboveAll(this Rect source, Rect target, int i)
* Cover(this Rect source, params Rect[] targets)
* StretchedVerticallyAlong(this Rect source, Rect target)
* AddHeight(this Rect source, int height)
* AddWidth(this Rect source, int width)
