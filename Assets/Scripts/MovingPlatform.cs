using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    private Vector2 startPos;
    private Vector2 endPos;
    private float direction;
    private float t = 0f;
    private float disableOffset;


    public float speed = 2f;
    public float moveDistance = 3f;

  

    void Start()
    {
        startPos = transform.position;
        endPos = startPos + Vector2.right * moveDistance;
        direction = 1;
        disableOffset = 6f;
    }

    // Update is called once per frame
    void Update()
    {
        t += direction * speed * Time.deltaTime / moveDistance; 
        transform.position = Vector2.Lerp(startPos, endPos, Mathf.PingPong(t,1)); //pinpong's return value is toggling betweing 0 -> 1 -> 0 -> 1 and t is the intervals of interpolation 
    }

    private void LateUpdate()
    {
        if (transform.position.y + disableOffset < Camera.main.transform.position.y) { 
         gameObject.SetActive(false);
        }
    }
}
