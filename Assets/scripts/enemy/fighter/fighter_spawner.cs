using UnityEngine;

public class fighter_spawner : MonoBehaviour
{
    public GameObject prefabToSpawn;   // ������ ������
    public float spawnInterval = 60f;  // 60�ʸ��� ����
    

    private float timer = 0f;

    void Update()
    {
        // �ð� ����
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnPrefab();
            timer = 0f;  // Ÿ�̸� �ʱ�ȭ
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
