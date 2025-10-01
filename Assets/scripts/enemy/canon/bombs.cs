using UnityEngine;

public class bombs : MonoBehaviour
{
    public float speed = 10f;   
    public bool goRight = true; 
    public GameObject bomb_effect;

    public float ps = 1;
    public float ms = 2;

    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody>();
        } 
            

        rb.useGravity = false;
        rb.isKinematic = false; 

        Vector3 dir = goRight ? Vector3.right : Vector3.left;
        rb.AddForce(dir * speed, ForceMode.Impulse);

        bomb_effect.SetActive(false);
    }

    

    
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("katana"))
        {
            bomb_effect.SetActive(true);
            Destroy(gameObject, 0.3f);
            if (socre_counter.Instance != null)
            {
                socre_counter.Instance.add_score(ps);
            }
        }

        else if (other.gameObject.CompareTag("wall"))
        {
            bomb_effect.SetActive(true);
            Destroy(gameObject, 0.3f);
            if (socre_counter.Instance != null)
            {
                socre_counter.Instance.add_score(-ms);
            }
        }
    }
}
