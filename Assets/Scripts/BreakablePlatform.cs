using Assets.Scripts;
using UnityEngine;

public class BreakablePlatform : MonoBehaviour
{

    private void LateUpdate()
    {
        float disableOffset = 6f;
        if (transform.position.y + disableOffset < ScreenBounds.LetfY)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
        }
    }
}
