using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class prochb : MonoBehaviour
{
    public Slider slider;
    public shield s;

    public void Update()
    {
        slider.value = s.shieldhealth;
    }


    
    
}
