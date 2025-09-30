using UnityEngine;

public class katana_effect : MonoBehaviour
{
    public GameObject effect;

    private void Start()
    {
        effect.SetActive(false);
    }

    public void on_effect()
    {
       
        effect.SetActive(true);
        
    }

    public void off_effect() 
    {
        effect.SetActive(false);
    }

}
