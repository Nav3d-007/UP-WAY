using Assets.Scripts;
using UnityEngine;

public class FallingEnemySpawner : MonoBehaviour
{
    private Camera cam; //cacheing the camera 
    private float spawnTimer;

    [SerializeField] private float yOffset = 2f;
    [SerializeField] private float enemySpawnXOffset = -2.5f;
    [SerializeField] private float spawnDelay = 4f;


    public GameObject fallingEnemyPrefab;
    public Transform player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = Camera.main;
        SetupTimer();
    }

    // Update is called once per frame
    void Update()
    {
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnDelay)
        {
            var topLeft = ViewportPoints.TopLeft; 

            var spawnPos = new Vector2(topLeft.x, topLeft.y + yOffset);
            spawnPos = cam.ViewportToWorldPoint(spawnPos); 

            var offsettedPlayerPosX = player.position.x + Random.Range(-enemySpawnXOffset, enemySpawnXOffset);

            var spawnAroundPlayer = new Vector2(offsettedPlayerPosX, spawnPos.y); //SNAPPY DIRECTLY ZAPPY 

            Instantiate(fallingEnemyPrefab, spawnAroundPlayer, Quaternion.identity);
            spawnTimer = 0f;
        }
    }

    private void SetupTimer()
    {
        spawnTimer = 0f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
        }
    }
}
