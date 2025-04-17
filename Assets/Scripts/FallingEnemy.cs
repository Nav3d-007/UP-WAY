using Assets.Scripts;
using UnityEngine;

public class FallingEnemy : MonoBehaviour
{
    [SerializeField] private float fallSpeed = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        UpdateEnemy();
    }

    private void UpdateEnemy()
    {
        transform.Translate(Vector2.down * fallSpeed * Time.deltaTime);
    }

    private void LateUpdate()
    {
        float disableOffset = 6f;
        if (transform.position.y + disableOffset < ScreenBounds.LetfY)
        {
            gameObject.SetActive(false);
        }
    }

}
