
using UnityEngine;

namespace Assets.Scripts
{
    public static class ScreenBounds
    {
        private static Camera _mainCamera => Camera.main; //cacheing the camera for performance 

        public static float Left => _mainCamera.ViewportToWorldPoint(new Vector2(0f, 0f)).x;
        public static float Right => _mainCamera.ViewportToWorldPoint(new Vector2(1f, 0f)).x;
        public static float Top => _mainCamera.ViewportToWorldPoint(new Vector2(0f, 1f)).y;
        public static float Bottom => _mainCamera.ViewportToWorldPoint(new Vector2(0f, 0f)).y;


        //IMPORTANT - DO NOT use non primitive return types with this class in Update()
        //ViewportToWorldPoint returns Vector3, and calling it statically every frame 
        //leads to weird/unpredictable behavior
    }

}
