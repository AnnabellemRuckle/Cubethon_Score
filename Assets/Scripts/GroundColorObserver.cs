using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundColorObserver : MonoBehaviour
{
    public float colorChangeInterval = 1f; 
    public Color[] colors = new Color[]
    {
        Color.red,
        Color.green,
        Color.blue,
        Color.yellow,
        Color.cyan,
        Color.magenta,
    }; 

    private Renderer groundRenderer;
    private int currentColorIndex = 0;
    private float timer = 0f;

    void Start()
    {
        groundRenderer = GetComponent<Renderer>();

        
        if (colors.Length > 0)
        {
            groundRenderer.material.color = colors[currentColorIndex];
        }
        else
        {
            Debug.LogError("No colors defined in the 'colors' array.");
        }
    }

    void Update()
    {
       
        timer += Time.deltaTime;
        if (timer >= colorChangeInterval)
        {
            timer = 1f;
            currentColorIndex = (currentColorIndex + 1) % colors.Length;
            groundRenderer.material.color = colors[currentColorIndex];
        }
    }
}
