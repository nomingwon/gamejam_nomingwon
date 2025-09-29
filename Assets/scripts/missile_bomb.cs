using UnityEngine;

public class missile_bomb : MonoBehaviour
{
    void Start()
    {
        transform.rotation = Quaternion.Euler(180, 0, 0);
    }
    // 트리거 충돌 감지
    private void OnTriggerEnter(Collider other)   // ✅ Collider 대문자
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // 0.3초 후 파괴
            Destroy(gameObject, 0.3f);
        }

        if (other.gameObject.CompareTag("katana"))
        {
            // 즉시 파괴
            Destroy(gameObject);
        }
    }
}
