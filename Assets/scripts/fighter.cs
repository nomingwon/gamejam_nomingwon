using UnityEngine;

public class fighter : MonoBehaviour
{
    public float speed = 10f;   // �߻� �ӵ�
    private Rigidbody rb;
    
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody>();
        }

        rb.useGravity = false;
        rb.isKinematic = false; // ���� �浹�� �Ͼ���� non-kinematic�̾�� ��

        // z��(+Forward) �������� ���� ����
        Vector3 dir = Vector3.forward;
        rb.AddForce(dir * speed, ForceMode.Impulse);
    }
    void Update()
    {
       
    }
   

    
    // 3D Ʈ����
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("wall"))
        {
            Destroy(gameObject, 0.01f);
        }
    }
    
}
