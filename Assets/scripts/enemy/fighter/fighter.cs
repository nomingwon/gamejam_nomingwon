using UnityEngine;

public class fighter : MonoBehaviour
{
    public float speed = 10f;   
    private Rigidbody rb;
    
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody>();
        }

        rb.isKinematic = false; 
        
        Vector3 dir = Vector3.forward;
        rb.AddForce(dir * speed, ForceMode.Impulse);
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("wall"))
        {
            Destroy(gameObject, 0.01f);
        }
    }
    
}
