using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class spawnslider : MonoBehaviour
{
   public Slider slider;
    public GameObject ws;
    public TextMeshProUGUI text;
    void Update()
    {
        wavespawn e = ws.GetComponent<wavespawn>();
        slider.value = e.spawnfloat;

        if(slider.value < 2) {
            text.text = "SPAWNING...";
        }
        if(slider.value >=2) {
            text.text = "SPAWNED!";
        }
    }
}
