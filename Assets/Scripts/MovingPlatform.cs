using Assets.Scripts;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    private Vector2 startPos;
    private Vector2 endPos;
    private float direction;
    private float t = 0f;

    public float speed = 2f;
    public float moveDistance = 3f;

  

    void Start()
    {
        startPos = transform.position;
        endPos = startPos + Vector2.right * moveDistance;
        direction = 1;
    }

    // Update is called once per frame
    void Update()
    {
        t += direction * speed * Time.deltaTime / moveDistance; 
        transform.position = Vector2.Lerp(startPos, endPos, Mathf.PingPong(t,1)); //pinpong's return value is toggling betweing 0 -> 1 -> 0 -> 1 and t is the intervals of interpolation 
    }

    private void LateUpdate()
    {
        float disableOffset = 6f;
        if (transform.position.y + disableOffset < ScreenBounds.LetfY) { 
         gameObject.SetActive(false);
        }
    }
}
