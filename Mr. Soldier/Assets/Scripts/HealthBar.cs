using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    //Reference to the slider components.
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void SetMaxHealth(int health)
    {
        //Set the slider values to the player health.
        slider.maxValue = health;
        slider.value = health;
        //Evaluate calculates the slider values from 0-1 and turns it into percentages.
        fill.color = gradient.Evaluate(1f);
    }
    public void SetHealth(int health)
    {
        //Sets the current health of the player to the slider.
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
