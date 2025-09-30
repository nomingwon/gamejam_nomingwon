using UnityEngine;

public class bombs_left : MonoBehaviour
{
    public float speed = 10f;   // �߻� �ӵ�
    public bool goRight = false; // true�� +X, false�� -X
    

    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb == null) rb = gameObject.AddComponent<Rigidbody>();

        rb.useGravity = false;
        rb.isKinematic = false; // ���� �浹�� �Ͼ���� �Ϲ������� non-kinematic

        Vector3 dir = goRight ? Vector3.right : Vector3.left;
        rb.AddForce(dir * speed, ForceMode.Impulse);

        
    }

    // 3D �浹(��-Ʈ����)
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("asdfhadkfkzsfhselaofjepdo");
        if (other.gameObject.CompareTag("katana"))
        {

            Destroy(gameObject, 0.01f);
        }
    }

    // 3D Ʈ����
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("katana"))
        {

            Destroy(gameObject, 0.03f);
        }
    }
}
