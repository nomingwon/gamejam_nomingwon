using UnityEngine;

public class bombs_left : MonoBehaviour
{
    public float speed = 10f;   // 발사 속도
    public bool goRight = false; // true면 +X, false면 -X
    

    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb == null) rb = gameObject.AddComponent<Rigidbody>();

        rb.useGravity = false;
        rb.isKinematic = false; // 물리 충돌이 일어나려면 일반적으로 non-kinematic

        Vector3 dir = goRight ? Vector3.right : Vector3.left;
        rb.AddForce(dir * speed, ForceMode.Impulse);

        
    }

    // 3D 충돌(비-트리거)
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("asdfhadkfkzsfhselaofjepdo");
        if (other.gameObject.CompareTag("katana"))
        {

            Destroy(gameObject, 0.01f);
        }
    }

    // 3D 트리거
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("katana"))
        {

            Destroy(gameObject, 0.03f);
        }
    }
}
