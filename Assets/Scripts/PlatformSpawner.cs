using Assets.Scripts;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{    
    public GameObject staticPlatformPrfab;
    public GameObject movingPlatformPrfab;
    public GameObject brekablePlatformPrefab;


    private float lastSpawnY;
    private Camera cam; //cacheing the camera 

    [SerializeField] private float spawnGap = 4f;// how far away the plaformarms from each other
    [SerializeField] private float yOffset = 2f; //how much above the platform should spawn at above the window top
    [SerializeField] private float specialPlatformXOffset = 1.5f;
    [SerializeField] private float randomnessXAndYOffset = 3.5f;
    [SerializeField] private float specialPlatformSpawnChance = 0.5f;//50% probability for a special platform to spawn 


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
        Vector2 midTop = cam.ViewportToWorldPoint(ViewportPoints.MidTop);//have to do here cuz camera is moving Y cord is changing

        //THIS IS A MESS RN but this algo can be tuned more for special platforms to be more dynamic and incorporating increasing score as incrasing difficulty
        //also could implmenet object pooling for spawning 
        if (midTop.y > lastSpawnY + spawnGap)
        {
            var randomX = Random.Range(ScreenBounds.LeftX + randomnessXAndYOffset, ScreenBounds.RightX - randomnessXAndYOffset);
            randomX = Mathf.Clamp(randomX, ScreenBounds.LeftX + randomnessXAndYOffset, ScreenBounds.RightX - randomnessXAndYOffset);

            var spawnPos = new Vector2(randomX, midTop.y + yOffset);

            if (Random.value < specialPlatformSpawnChance)
            {
                float specialOffsetX = Random.Range(-spawnPos.x * specialPlatformXOffset, spawnPos.x * specialPlatformXOffset);
                float specialOffsetY = Random.Range(1.5f, 3.8f);//just for vertical variations

                var specialSpawnPos = new Vector2(spawnPos.x + specialOffsetX, spawnPos.y + specialOffsetY);

                if (Random.value < 0.5f) //for now lets just choose between the two
                    Instantiate(movingPlatformPrfab, specialSpawnPos, Quaternion.identity);
                else
                    Instantiate(brekablePlatformPrefab, specialSpawnPos, Quaternion.identity);
            }
            Instantiate(staticPlatformPrfab, spawnPos, Quaternion.identity);
            lastSpawnY = spawnPos.y;
        }
    }

}
