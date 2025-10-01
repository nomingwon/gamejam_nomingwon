using UnityEngine;

public class fighter_spawner : MonoBehaviour
{
    public GameObject prefabToSpawn;   
    public float spawnInterval = 60f;  
    

    private float timer = 0f;

    void Update()
    {
        
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnPrefab();
            timer = 0f;  
            spawnInterval -= 5f;
        }
    }

    void SpawnPrefab()
    {
        if (prefabToSpawn != null)
        {
            Instantiate(prefabToSpawn, transform.position, Quaternion.identity);
        }
    }
}
