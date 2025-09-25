using System;
using UnityEngine;

public class BackgroundColorChange : MonoBehaviour
{
    [SerializeField] Color[] colorArray;

    Camera mainCamera;

    void Start()
    {
        mainCamera = gameObject.GetComponent<Camera>();
    }

    float timer1;
    void Update()
    {
        if (Time.time > timer1)
        {
            timer1 = Time.time + 3;
            mainCamera.backgroundColor = nextColor();
        }
    }

    int currentColorIndex = 0;
    Color nextColor()
    {
        Color returnColor = colorArray[currentColorIndex];
        currentColorIndex++;
        if (currentColorIndex >= colorArray.Length)
        {
            currentColorIndex = 0;
        }
        return returnColor;
    }
}
