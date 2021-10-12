using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPicker : MonoBehaviour
{
    public Color[] colors;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("ColorPickers");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ColorPickers()
    {
        while(true)
        {
            int randomColor = Random.Range(0, 5);
            Camera.main.backgroundColor = colors[randomColor];
            yield return new WaitForSeconds(10);
        }
    }
}
