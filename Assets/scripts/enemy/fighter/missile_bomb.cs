using UnityEngine;

public class missile_bomb : MonoBehaviour
{
    
    public GameObject effectBombPrefab;     
    public GameObject destroyedBombPrefab;   
    public float ps = 100f;
    public float ms = 200f;

    
 

    void Start()
    {
        transform.rotation = Quaternion.Euler(180f, 0f, 0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (socre_counter.Instance != null)
            {
                socre_counter.Instance.add_score(-ms);
            }
            effect(effectBombPrefab);
            Destroy(gameObject,0.1f); 
        }
        else if (other.CompareTag("katana"))
        {
            if (socre_counter.Instance != null)
            {
                socre_counter.Instance.add_score(ps);
            }
            effect(destroyedBombPrefab);
            Destroy(gameObject);
        }
    }

    void effect(GameObject prefab)
    {
        if (prefab == null)
        {
            return;
        }
        GameObject ef = Instantiate(prefab, transform.position, Quaternion.identity);

       
        Destroy(ef, 2f);
    }
}
