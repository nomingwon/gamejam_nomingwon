using UnityEngine;

public class bitlightdemo : MonoBehaviour
{
    uint light = 0;
    public GameObject[] cubes;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            light = light ^ (1 << 0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            light = light ^ (1 << 1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            light = light ^ (1 << 2);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            light = 0;
        }
        

        for(int i =0; i<cubes.Length; i++)
        {
            bool on = (light & (1 << i)) != 0;
            cubes[i].GetComponent<Renderer>().material.color = on ?
                Color.yellow : Color.gray;

        }

        if (Input.anyKey)
        {
            string bin =System.Convert.ToString(light,2).PadLeft(4,'0');
            Debug.Log($"light(bin)={bin} int{light}");
        }
    }
}
