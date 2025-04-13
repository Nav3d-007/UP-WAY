using UnityEngine;

namespace Assets.Scripts
{
    public static class ViewportPoints
    {
        public static readonly Vector2 TopLeft = new Vector2(0f, 1f);
        public static readonly Vector2 TopRight = new Vector2(1f, 1f);
        public static readonly Vector2 BottomLeft = new Vector2(0f, 0f);
        public static readonly Vector2 BottomRight = new Vector2(1f, 0f);
        public static readonly Vector2 Center = new Vector2(0.5f, 0.5f);
        public static readonly Vector2 MidTop = new Vector2(0.5f, 1f);
        public static readonly Vector2 MidBottom = new Vector2(0.5f, 0f);
    }
}
