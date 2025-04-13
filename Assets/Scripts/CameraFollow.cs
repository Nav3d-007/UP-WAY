using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;

    private void LateUpdate()
    {
        FollowPlayerY();
           
    }

    private void FollowPlayerY()
    {
         float smoothSpeed = 5f;

        if (player.position.y > transform.position.y)
        {
            Vector2 currentPos = transform.position;
            Vector2 targetPos = new Vector2(currentPos.x, player.position.y);

            //whenver doing lerp alwasy multiply by Time.Delta cuz should be consistent across varying hardware blah blah
            Vector2 newPos = Vector2.Lerp(currentPos, targetPos, smoothSpeed * Time.deltaTime);

            transform.position = new Vector3(newPos.x, newPos.y, transform.position.z); //cant avoid user a vector2 cuz its a camera its needs the z axis

        }
    }
}
