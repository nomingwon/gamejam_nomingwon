using UnityEngine;

public class fighter_spawner : MonoBehaviour
{
    public GameObject prefabToSpawn;   // 생성할 프리팹
    public float spawnInterval = 60f;  // 60초마다 생성
    

    private float timer = 0f;

    void Update()
    {
        // 시간 누적
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnPrefab();
            timer = 0f;  // 타이머 초기화
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
