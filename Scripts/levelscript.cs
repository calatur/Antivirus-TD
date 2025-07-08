using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class levelscript : MonoBehaviour
{
    public Button[] levels;
    
    
   
    void Start()
    {  
      int  index = PlayerPrefs.GetInt("unlocked", 1);
        for (int j = 0; j < levels.Length; j++) {
            if (j + 1 > index) {
                levels[j].interactable = false; } }
    }

   
}
