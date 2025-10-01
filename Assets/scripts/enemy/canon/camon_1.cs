using UnityEngine;

public class camon_1 : MonoBehaviour
{
    
    public GameObject bomb_right;
    public GameObject dynamite_right;
    public GameObject dynamite_triple_right;
    public GameObject barrel_right;
    public GameObject shoot_effect;
    

    public float spawnInterval = 1f;       
    public float minSpawnInterval = 0.2f;  
    public float speedUpRate = 0.05f;      
    public float speedUpStart = 30f;       
    

    private float timer;
    private float elapsed;

    void Update()
    {
        elapsed += Time.deltaTime;
        timer += Time.deltaTime;

        
        if (elapsed >= speedUpStart)
        {
            
            spawnInterval = Mathf.Max(minSpawnInterval,spawnInterval - speedUpRate * Time.deltaTime);
        }

        
        if (timer >= spawnInterval)
        {
            Spawn(elapsed);
            timer = 0f;
        }
    }

    void Spawn(float t)
    {
        GameObject clone = Instantiate(shoot_effect, transform.position, Quaternion.identity);
        Destroy(clone, 2f);
        
        if (t < 30f)
        {
            Instantiate(bomb_right, transform.position, Quaternion.identity);
        }
        
        else if (t < 60f)
        {
            Instantiate(Random.value < 0.5f ? bomb_right : dynamite_right, transform.position, Quaternion.identity);
        }
        
        else if (t < 90f)
        {
            float r = Random.value;
            if (r < 0.33f) Instantiate(bomb_right, transform.position, Quaternion.identity);
            else if (r < 0.66f) Instantiate(dynamite_right, transform.position, Quaternion.identity);
            else Instantiate(dynamite_triple_right, transform.position, Quaternion.identity);
        }
        
        else
        {
            float r = Random.value;
            if (r < 0.25f) Instantiate(bomb_right, transform.position, Quaternion.identity);
            else if (r < 0.5f) Instantiate(dynamite_right, transform.position, Quaternion.identity);
            else if (r < 0.75f) Instantiate(dynamite_triple_right, transform.position, Quaternion.identity);
            else Instantiate(barrel_right, transform.position, Quaternion.identity);
        }
    }
}
