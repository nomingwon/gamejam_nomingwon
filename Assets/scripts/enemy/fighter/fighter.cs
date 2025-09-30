using UnityEngine;

public class fighter : MonoBehaviour
{
    public float speed = 10f;   // 발사 속도
    private Rigidbody rb;
    
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody>();
        }

        rb.useGravity = false;
        rb.isKinematic = false; // 물리 충돌이 일어나려면 non-kinematic이어야 함

        // z축(+Forward) 방향으로 힘을 가함
        Vector3 dir = Vector3.forward;
        rb.AddForce(dir * speed, ForceMode.Impulse);
    }
    void Update()
    {
       
    }
   

    
    // 3D 트리거
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("wall"))
        {
            Destroy(gameObject, 0.01f);
        }
    }
    
}
