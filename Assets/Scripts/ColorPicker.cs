using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPicker : MonoBehaviour
{
    public List<Color> avaibleColors;
    public List<Color> currentColors;

    [Space]
    public Color startColor; 
    public Color targetColor; 
    public Color currentColor;

    [Space]
    public int step;
    public int currentStep; 

    public void Init()
    {
        currentColors.AddRange(avaibleColors);
        PickColor(out startColor);
        PickColor(out targetColor);
    }

    public void PickColor(out Color color)
    {
        //jesli skonczyly sie kolory to zainicjuj nowe:
        if(currentColors.Count == 0)
        {
            currentColors.AddRange(avaibleColors); 
        }

        //losowanie koloru
        color = currentColors[Random.Range(0, currentColors.Count)];
        currentColors.Remove(color); 
    }

    public Color GetCurrentColor()
    {
        currentColor = Color.Lerp(startColor, targetColor, (float)currentStep / step);
        return currentColor; 
    }

    public void IncreaseStep()
    {
        currentStep++; 

        if(currentStep >= step)
        {
            startColor = targetColor;
            PickColor(out targetColor);
            currentStep = 0; 
        }
    }

}
