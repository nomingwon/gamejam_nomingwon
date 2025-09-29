using UnityEngine;


public class player_anime : MonoBehaviour
{
    public Animator anime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anime=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        attack();
        turn();
    }

    public void attack()
    {
        var st = anime.GetCurrentAnimatorStateInfo(0);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anime.SetTrigger("attack1");
            if (st.IsName("Attack_5Combo_1") && Input.GetKeyDown(KeyCode.Space))
            {
                anime.ResetTrigger("attack1");
                anime.SetTrigger("attack2");
            }
            else if(st.IsName("Attack_5Combo_2") && Input.GetKeyDown(KeyCode.Space))
            {
                anime.ResetTrigger("attack2");
                anime.SetTrigger("attack1");
            }
        }
    }

    public void turn()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
            anime.SetTrigger("turn");
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            transform.rotation = Quaternion.Euler(0, 270, 0);
            anime.SetTrigger("turn");
        }
    }
}
