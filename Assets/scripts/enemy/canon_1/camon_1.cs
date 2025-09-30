using UnityEngine;

public class camon_1 : MonoBehaviour
{
    [Header("Spawn Prefabs")]
    public GameObject bomb_right;
    public GameObject dynamite_right;
    public GameObject dynamite_triple_right;
    public GameObject barrel_right;
    public GameObject shoot_effect;
    [Header("Spawn Settings")]
    public float spawnInterval = 1f;       // �ʱ� ���� ����
    public float minSpawnInterval = 0.2f;  // �ּ� ���� (�ʹ� �������� �� ����)
    public float speedUpRate = 0.05f;      // ���� �ӵ� (�ʴ� �󸶳� ��������)
    public float speedUpStart = 30f;       // �� �� �ں��� ���� ��������
    

    private float timer;
    private float elapsed;

    void Update()
    {
        elapsed += Time.deltaTime;
        timer += Time.deltaTime;

        // ���� �ð��� ������ ���� ���� ���� ����
        if (elapsed >= speedUpStart)
        {
            // ��� �ð��� ����ؼ� ���ҽ�Ű��, minSpawnInterval ���Ϸδ� �� ��������
            spawnInterval = Mathf.Max(minSpawnInterval,
                                      spawnInterval - speedUpRate * Time.deltaTime);
        }

        // ��ź ����
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
        // 0~30�� : bomb��
        if (t < 30f)
        {
            Instantiate(bomb_right, transform.position, Quaternion.identity);
        }
        // 30~60�� : bomb + dynamite
        else if (t < 60f)
        {
            Instantiate(Random.value < 0.5f ? bomb_right : dynamite_right,
                        transform.position, Quaternion.identity);
        }
        // 60~90�� : bomb + dynamite + triple
        else if (t < 90f)
        {
            float r = Random.value;
            if (r < 0.33f) Instantiate(bomb_right, transform.position, Quaternion.identity);
            else if (r < 0.66f) Instantiate(dynamite_right, transform.position, Quaternion.identity);
            else Instantiate(dynamite_triple_right, transform.position, Quaternion.identity);
        }
        // 90�� ���� : �� ���� ���
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
