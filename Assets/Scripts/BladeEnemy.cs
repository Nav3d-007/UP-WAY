using UnityEngine;

public class BladeEnemy : MonoBehaviour
{
    //startX and direction have to be class level otherwise gameplay breaks there is nasty bug where both blades collide with each other become one and werid things happen
    private float startX;
    private float direction; 


    [SerializeField] private float waveFrequency = 1.3f;
    [SerializeField] private float waveAplitute = 3.5f;
    [SerializeField] private float speed = 3.5f;


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
