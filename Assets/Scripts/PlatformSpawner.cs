using Assets.Scripts;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{    
    public GameObject staticPlatformPrfab;
    public GameObject movingPlatformPrfab;
    public GameObject brekablePlatformprefab;


    private float lastSpawnY;
    private Camera cam; //cacheing the camera 

    void Start()
    {
        cam = Camera.main;
        lastSpawnY = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        SpawnPlatforms();
    }


    private void SpawnPlatforms()
    {
        Vector2 midTop = cam.ViewportToWorldPoint(new Vector2(0.5f, 1f));//have to do here cuz camera is moving Y cord is changing
        float spawnGap = 4f; // how far away the platformarms from each other

        //diffuculty controlling algo can be tuned more for special platforms to be more dynamic
        if (midTop.y > lastSpawnY + spawnGap)
        {
            float randomnessXAndYOffset = 3.5f;
            float yOffset = 2f;
            float specialPlatformSpawnChance = 0.5f; //50% probability for a special platform to spawn 

            var radomX = Random.Range(ScreenBounds.Left + randomnessXAndYOffset, ScreenBounds.Right - randomnessXAndYOffset);
            var spawnPos = new Vector2(radomX, midTop.y + yOffset);

            if (Random.value < specialPlatformSpawnChance)
            {
                float specialPlatformSpawnOffset = Random.Range(-randomnessXAndYOffset, randomnessXAndYOffset);

                var specialSpawnPos = new Vector2(spawnPos.x + specialPlatformSpawnOffset, spawnPos.y + specialPlatformSpawnOffset);

                if (Random.value < 0.5f) //for now lets just choose between the two
                    Instantiate(movingPlatformPrfab, specialSpawnPos, Quaternion.identity);
                else
                    Instantiate(brekablePlatformprefab, specialSpawnPos, Quaternion.identity);

            }

            Instantiate(staticPlatformPrfab, spawnPos, Quaternion.identity);
            lastSpawnY = spawnPos.y;
        }
    }
}
