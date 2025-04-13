using Assets.Scripts;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{    
    public GameObject staticPlatformPrfab;
    public GameObject movingPlatformPrfab;
    public GameObject brekablePlatformPrefab;


    private float lastSpawnY;
    private Camera cam; //cacheing the camera 
    private float LEFT_BOUND; //both for cacheing purpose inseat of accessing the static ScreenBound in the Update() every frame
    private float RIGHT_BOUND;

    [SerializeField] private float spawnGap = 4f;// how far away the plaformarms from each other
    [SerializeField] private float yOffset = 2f; //how much above the platform should spawn at above the window top
    [SerializeField] private float randomnessXAndYOffset = 3.5f;
    [SerializeField] private float specialPlatformSpawnChance = 0.5f;//50% probability for a special platform to spawn 



    void Start()
    {
        cam = Camera.main;
        lastSpawnY = 0f;
        LEFT_BOUND = ScreenBounds.Left;
        RIGHT_BOUND = ScreenBounds.Right;
    }

    // Update is called once per frame
    void Update()
    {
        SpawnPlatforms();
    }


    private void SpawnPlatforms()
    {
        Vector2 midTop = cam.ViewportToWorldPoint(new Vector2(0.5f, 1f));//have to do here cuz camera is moving Y cord is changing

        //diffuculty controlling algo can be tuned more for special platforms to be more dynamic and incorporating increasing as incrasing difficulty
        if (midTop.y > lastSpawnY + spawnGap)
        {
            var randomX = Random.Range(LEFT_BOUND + randomnessXAndYOffset, RIGHT_BOUND - randomnessXAndYOffset);

            var spawnPos = new Vector2(randomX, midTop.y + yOffset);

            if (Random.value < specialPlatformSpawnChance)
            {
                float specialPlatformSpawnOffset = Random.Range(-randomnessXAndYOffset, randomnessXAndYOffset);

                var specialSpawnPos = new Vector2(spawnPos.x + specialPlatformSpawnOffset, spawnPos.y + specialPlatformSpawnOffset);

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
