using UnityEngine;

public class enemy : MonoBehaviour
{
    public Animator anime;

    void Start()
    {
        anime = GetComponent<Animator>();
    }

    // Collider 기반 트리거 감지
    private void OnTriggerEnter(Collider other)
    {
        // 여러 태그 체크
        if (other.CompareTag("bomb") || other.CompareTag("missile"))
        {
            anime.SetTrigger("hit");
        }
    }

    // 기존 Collision도 필요하면 남겨둘 수 있음
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("bomb"))
        {
            anime.SetTrigger("hit");
        }
    }
}
