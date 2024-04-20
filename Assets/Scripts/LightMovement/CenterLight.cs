using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterLight : MonoBehaviour
{
    private Color[] colors =
        { Color.red,
          Color.blue,
          Color.yellow,
          new Color(0.05f, 0.7f, 0.1f), 
          new Color(0.1f, 0.05f, 0.025f) }; 

    private float colorChangeInterval = 0.5f; 
    private int currentIndex = 0; 

    private Light spotlight;

    void Start()
    {
        spotlight = GetComponent<Light>();
        
        spotlight.color = colors[currentIndex];
       
        StartCoroutine(CycleColors());
    }

    private IEnumerator CycleColors()
    {
        while (true)
        {
            yield return new WaitForSeconds(colorChangeInterval);

            currentIndex = (currentIndex + 1) % colors.Length;
            spotlight.color = colors[currentIndex];
        }
    }
}
