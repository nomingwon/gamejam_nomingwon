using UnityEngine;

public class canon_2 : MonoBehaviour
{
    [Header("Spawn Prefabs")]
    public GameObject bomb_right;
    public GameObject dynamite_right;
    public GameObject dynamite_triple_right;
    public GameObject barrel_right;
    public GameObject shoot_effect;

    [Header("Spawn Settings")]
    public float spawnInterval = 1f;       // 초기 스폰 간격
    public float minSpawnInterval = 0.2f;  // 최소 간격 (너무 빨라지는 것 방지)
    public float speedUpRate = 0.05f;      // 감소 속도 (초당 얼마나 빨라질지)
    public float speedUpStart = 30f;       // 몇 초 뒤부터 가속 시작할지

    private float timer;
    private float elapsed;

    void Update()
    {
        elapsed += Time.deltaTime;
        timer += Time.deltaTime;

        // 일정 시간이 지나면 스폰 간격 점점 감소
        if (elapsed >= speedUpStart)
        {
            // 경과 시간에 비례해서 감소시키되, minSpawnInterval 이하로는 안 내려가게
            spawnInterval = Mathf.Max(minSpawnInterval,
                                      spawnInterval - speedUpRate * Time.deltaTime);
        }

        // 폭탄 스폰
        if (timer >= spawnInterval)
        {
            Spawn(elapsed);
            timer = 0f;
        }
    }

    void Spawn(float t)
    {
        
        GameObject clone = Instantiate(shoot_effect, transform.position, Quaternion.identity);
        Destroy(clone, 2f);  

        // 0~30초 : bomb만
        if (t < 30f)
        {
            Instantiate(bomb_right, transform.position, Quaternion.identity);
        }
        // 30~60초 : bomb + dynamite
        else if (t < 60f)
        {
            Instantiate(Random.value < 0.5f ? bomb_right : dynamite_right,
                        transform.position, Quaternion.identity);
        }
        // 60~90초 : bomb + dynamite + triple
        else if (t < 90f)
        {
            float r = Random.value;
            if (r < 0.33f) Instantiate(bomb_right, transform.position, Quaternion.identity);
            else if (r < 0.66f) Instantiate(dynamite_right, transform.position, Quaternion.identity);
            else Instantiate(dynamite_triple_right, transform.position, Quaternion.identity);
        }
        // 90초 이후 : 네 종류 모두
        else
        {
            float r = Random.value;
            if (r < 0.25f) Instantiate(bomb_right, transform.position, Quaternion.identity);
            else if (r < 0.5f) Instantiate(dynamite_right, transform.position, Quaternion.identity);
            else if (r < 0.75f) Instantiate(dynamite_triple_right, transform.position, Quaternion.identity);
            else Instantiate(barrel_right, transform.position, Quaternion.identity);
        }
    }
}
