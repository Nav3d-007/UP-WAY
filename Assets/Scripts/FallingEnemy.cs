using UnityEngine;

public class FallingEnemy : MonoBehaviour
{
    public float fallSpeed;

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
}
