using UnityEngine;

public class enemy : MonoBehaviour
{
    public Animator anime;

    void Start()
    {
        anime = GetComponent<Animator>();
    }

    
   private void OnTriggerEnter(Collider other)
   {
        // 여러 태그 체크
        if (other.CompareTag("bomb") || other.CompareTag("missile"))
        {
            anime.SetTrigger("hit");
        }
    }

    
   /* private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("bomb"))
        {
            anime.SetTrigger("hit");
        }
    }*/
}
