
using UnityEngine;

namespace Assets.Scripts
{
    public static class ScreenBounds //returns world space co-ords
    {
        private static Camera _mainCamera => Camera.main; //cacheing it

        public static float LeftX => _mainCamera.ViewportToWorldPoint(new Vector2(0f, 0f)).x;
        public static float RightX => _mainCamera.ViewportToWorldPoint(new Vector2(1f, 0f)).x;
        public static float LetfY => _mainCamera.ViewportToWorldPoint(new Vector2(0f, 0f)).y;


        //IMPORTANT - DO NOT try to return non primitive types with this STATIC class in Update()
        //ViewportToWorldPoint returns Vector3, and calling it STATICALLY every frame  (with all the implicit castings)
        //leads to weird/unpredictable behavior

    }

}
