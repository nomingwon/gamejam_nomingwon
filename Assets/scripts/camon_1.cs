using UnityEngine;

public class camon_1 : MonoBehaviour
{
    [Header("Spawn Prefabs")]
    public GameObject bomb_right;
    public GameObject dynamite_right;
    public GameObject dynamite_triple_right;
    public GameObject barrel_right;

    [Header("Spawn Settings")]
    public float spawnInterval = 1f;

    private float timer;
    private float elapsed;   // 게임 시작 후 누적 시간

    void Update()
    {
        elapsed += Time.deltaTime;
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            Spawn(elapsed);
            timer = 0f;
        }
    }

    void Spawn(float t)
    {
        // 0~30초 : bomb만
        if (t < 30f)
        {
            Instantiate(bomb_right, transform.position, Quaternion.identity);
        }
        // 30~60초 : bomb + dynamite
        else if (t < 60f)
        {
            Instantiate(Random.value < 0.5f ? bomb_right : dynamite_right, transform.position, Quaternion.identity);
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
