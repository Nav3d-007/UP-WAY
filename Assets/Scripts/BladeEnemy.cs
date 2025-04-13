using UnityEngine;

public class BladeEnemy : MonoBehaviour
{
    //these have to be class level otherwise gameplay breaks there is nasty bug where both blades collide with each other become one and werid things happen
    private float startX;
    private float direction;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetupEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateEnemyMovement();
    }

    private void SetupEnemy()
    {
        startX = transform.position.x;
        direction = (startX < 0) ? 1 : -1;
    }

    private void UpdateEnemyMovement()
    {
        float waveFrequency = 1.3f;
        float waveAplitute = 3.5f;
        float speed = 3.5f;

        float xMovement = direction * speed * Time.deltaTime;

        //Time.time returns TOTAL TIME after game started and Time.deltaTime returns time PER FRAME
        var yOffset = (Mathf.Sin(Time.time * waveFrequency) * waveAplitute) * Time.deltaTime; //formula for calculating sinus motion wikipidai see if forget

        transform.position = new Vector2(transform.position.x + xMovement , transform.position.y + yOffset);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
        }
    }

}
