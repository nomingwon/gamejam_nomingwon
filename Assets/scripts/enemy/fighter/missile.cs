using UnityEngine;

public class missile : MonoBehaviour
{
    [Header("Missile Prefabs")]
    public GameObject missile_1;
    public GameObject missile_2;
    public GameObject missile_3;

    private bool drop_missile = false;

    void Update()
    {
        Drop();
    }

    private void Drop()
    {
        if (!drop_missile) return;

        float r = Random.value;
        if (r < 0.33f)
        {
            Instantiate(missile_1, transform.position, Quaternion.identity);
        }
        else if (r < 0.66f)
        {
            Instantiate(missile_2, transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(missile_3, transform.position, Quaternion.identity);
        }

       
        drop_missile = false;
    }

    private void OnTriggerEnter(Collider other)    
    {
        if (other.CompareTag("missile_trigger"))
        {
            drop_missile = true;
        }
    }
}
