using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public GameObject[] prefabsToSpawn;

    void Start()
    {
        InvokeRepeating("SpawnRandomPrefab", 0f, 2.0f);
    }

    void SpawnRandomPrefab()
    {
        int randomIndex = Random.Range(0, prefabsToSpawn.Length);
        
        GameObject chosenPrefab = prefabsToSpawn[randomIndex];

        float randomX = Random.Range(-6f, 6f);
        Vector3 spawnPosition = new Vector3(randomX, transform.position.y, 0f);

        Instantiate(chosenPrefab, spawnPosition, transform.rotation);
    }
}
