using Assets.Scripts;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject staticPlatformPrfab;
    public GameObject movingPlatformPrfab;
    public GameObject brekablePlatformPrefab;

    private Camera cam;

    private float nextSpawnY;

    [SerializeField] private float spawnGap = 10f;
    [SerializeField] private float yOffset = 2f;
    [SerializeField] private float specialPlatformXOffset = 1.5f;
    [SerializeField] private float randomnessXAndYOffset = 3.5f;
    [SerializeField] private float specialPlatformSpawnChance = 0.5f;

    void Start()
    {
        cam = Camera.main;
        nextSpawnY = cam.transform.position.y; 
    }

    void Update()
    {
        SpawnPlatforms();
    }

    private void SpawnPlatforms()
    {
        float topOfScreenY = cam.ViewportToWorldPoint(ViewportPoints.MidTop).y + yOffset;

        while (nextSpawnY < topOfScreenY)
        {
            float randomX = Random.Range(ScreenBounds.LeftX + randomnessXAndYOffset, ScreenBounds.RightX - randomnessXAndYOffset);
            randomX = Mathf.Clamp(randomX, ScreenBounds.LeftX + randomnessXAndYOffset, ScreenBounds.RightX - randomnessXAndYOffset);

            Vector2 spawnPos = new Vector2(randomX, nextSpawnY);

            // Special platform chance
            if (Random.value < specialPlatformSpawnChance)
            {
                float specialOffsetX = Random.Range(-specialPlatformXOffset, specialPlatformXOffset);
                float specialOffsetY = Random.Range(1.5f, 3.8f); // Vertical variation

                Vector2 specialSpawnPos = new Vector2(spawnPos.x + specialOffsetX, spawnPos.y + specialOffsetY);

                if (Random.value < 0.5f)
                    Instantiate(movingPlatformPrfab, specialSpawnPos, Quaternion.identity);
                else
                    Instantiate(brekablePlatformPrefab, specialSpawnPos, Quaternion.identity);
            }

            Instantiate(staticPlatformPrfab, spawnPos, Quaternion.identity);

            nextSpawnY += spawnGap; // Move up to next spawn point
        }
    }
}
