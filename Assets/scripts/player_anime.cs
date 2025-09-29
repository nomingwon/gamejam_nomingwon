using UnityEngine;

public class player_anime : MonoBehaviour
{
    public Animator anime;
    public Rigidbody rb;           // ? ������ Rigidbody
    public bool is_attack = false;
    public GameObject targetPrefab;   // 인스펙터에서 프리팹 인스턴스(씬 상 오브젝트) 지정
    [Header("Jump Settings")]
    public float jumpForce = 7f;   // ? ���� ��

    void Start()
    {
        anime = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();  // ? Rigidbody ��������
        targetPrefab.SetActive(false);
    }

    void Update()
    {
        attack();
        if (!is_attack)
        {
            turn();
        }
        katana_collider();
    }

    public void attack()
    {
        var st = anime.GetCurrentAnimatorStateInfo(0);
        
        
        

        // ------ ��Ÿ ------
        if (Input.GetKeyDown(KeyCode.Space))
        {

            anime.SetTrigger("attack1");

            
            if(st.IsName("attack1") && Input.GetKeyDown(KeyCode.Space))
            {
                anime.ResetTrigger("attack1");
                anime.SetTrigger("attack2");
            }
            

            else if (st.IsName("attack2") && Input.GetKeyDown(KeyCode.Space))
            {
                anime.ResetTrigger("attack2");
                anime.SetTrigger("attack1");
            }

            else if (st.IsName("attack1") && Input.GetKeyDown(KeyCode.W))
            {
                anime.ResetTrigger("attack1");
                anime.SetTrigger("jump_attack");
            }

            else if (st.IsName("UpperAttack") && Input.GetKeyDown(KeyCode.Space))
            {
                anime.ResetTrigger("jump_attack");
                anime.SetTrigger("attack1");
            }

            
        }

        // ------ ���� ���� ------
        if (Input.GetKeyDown(KeyCode.W))
        {
            anime.SetTrigger("jump_attack");
              // ? ���� ���� ����

            if (st.IsName("attack1") && Input.GetKeyDown(KeyCode.Space))
            {
                anime.ResetTrigger("attack1");
                anime.SetTrigger("jump_attack");
                 // ? ���� ���� ���� �ÿ��� ����
            }

            else if (st.IsName("attack2") && Input.GetKeyDown(KeyCode.Space))
            {
                anime.ResetTrigger("attack2");
                anime.SetTrigger("jump_attack");
            }
            
        }
    }

    // ? ���� ���� ó��
    private void Jump()
    {
        // ���� Y�ӵ��� �������� ������ ������ ������ �� ������,
        // ���� y�ӵ��� �ʱ�ȭ �� AddForce�� �ִ� ���� ������.
        Vector3 vel = rb.linearVelocity;
        vel.y = 0;
        rb.linearVelocity = vel;

        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
    
    public void On_attack()
    {
        is_attack = true;
    }
    public void Off_attack()
    {
        is_attack = false;
    }
 
    

    public void katana_collider()
    {
        if (is_attack)
        {
            targetPrefab.SetActive(true);
        }
        else
        {
            targetPrefab.SetActive(false);
        }
    }

    public void turn()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            transform.rotation = Quaternion.Euler(0, 270, 0);
        }
    }
   

    
   
        
}
