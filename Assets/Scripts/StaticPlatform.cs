using Assets.Scripts;
using UnityEngine;

public class StaticPlatform : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void LateUpdate()
    {
        float disableOffset = 6f;
        if (transform.position.y + disableOffset < ScreenBounds.LetfY)
        {
            gameObject.SetActive(false);
        }
    }
}
