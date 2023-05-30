using System;
using UnityEngine;

namespace Assets.Scripts
{
    public abstract class Bounds2D : ScriptableObject
    {
        public abstract float TopEdgeY { get; }
        public abstract float BottomEdgeY { get; }
        public abstract float LeftEdgeX { get; }
        public abstract float RightEdgeX { get; }
        public abstract float Height { get; }
        public abstract float Width { get; }
        public abstract Vector2 Center { get; }

        public bool IsInside(Vector2 vector2)
        {
           return vector2.x < RightEdgeX && vector2.x > LeftEdgeX && vector2.y < TopEdgeY && vector2.y > BottomEdgeY;
        }
    }
}
