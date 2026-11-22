using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject birdPrefab;
    public float spawnInterval = 2f;
    private float spawnTimer = 0f;

    public float spawnRange = 5f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnInterval)
        {
            SpawnBird();
            spawnTimer = 0f;
        }
    }

    private void SpawnBird()
    {
        Vector2 cameraPosition = Camera.main.transform.position;
        Vector2 spawnPosition;
        float spawnOffsetX = Camera.main.orthographicSize * Camera.main.aspect + 1f;




        int LorR = Random.Range(0, 2);
        if (LorR == 1)
        {
            spawnPosition = new Vector2(
            cameraPosition.x + spawnOffsetX,
            cameraPosition.y + Random.Range(-spawnRange, spawnRange));
        }
        else
        {
            spawnPosition = new Vector2(
            cameraPosition.x - spawnOffsetX,
            cameraPosition.y + Random.Range(-spawnRange, spawnRange));
        }
        GameObject newBird = Instantiate(birdPrefab, spawnPosition, Quaternion.identity);

        newBird.GetComponent<SpriteRenderer>().flipX = (LorR == 0);

        BirdMovement movement = newBird.GetComponent<BirdMovement>();

        movement.isLeftToRight = (LorR == 0);
        Instantiate(newBird, spawnPosition, Quaternion.identity);
    }
}
