using Assets.Scripts;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BladeEnemySpawner : MonoBehaviour
{
    private float spawnTimer;
    private Camera cam; //cacheing the camera 

    public GameObject bladePrefab;

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
        var leftTop = cam.ViewportToWorldPoint(new Vector2(0f, 1f));//i have to do this here cuZ camera is moving 
        var rightTop = cam.ViewportToWorldPoint(new Vector2(1f, 1f));// and cant use ScreenBounds in update, see the class for reason

        float ySpawnOffset = 2.5f; float delay = 5f;

        var spawnLeftPos = new Vector2(leftTop.x, leftTop.y + ySpawnOffset);
        var spawnRightPos = new Vector2(rightTop.x, rightTop.y + ySpawnOffset);


        spawnTimer += Time.deltaTime;
        if (spawnTimer >= delay)
        {
            Instantiate(bladePrefab, spawnLeftPos, Quaternion.identity);
            Instantiate(bladePrefab, spawnRightPos, Quaternion.identity);
            spawnTimer = 0f;
        }
    }

    private void SetupTimer()
    {
        spawnTimer = 0f; 
    }
}
