using Assets.Scripts;
using UnityEngine;

public class FallingEnemy : MonoBehaviour
{

    private void LateUpdate()
    {
        float disableOffset = 6f;
        if (transform.position.y + disableOffset < ScreenBounds.LetfY)
        {
            gameObject.SetActive(false);
        }
    }

}
