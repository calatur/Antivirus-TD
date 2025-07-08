using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthbarsc : MonoBehaviour
{
    public Slider slider;

    public void maxHealth(int maxh)
    {
        slider.maxValue = maxh;
        slider.value = maxh;
    }
    public void health(int health)
    {
        slider.value = health;
    }
}
