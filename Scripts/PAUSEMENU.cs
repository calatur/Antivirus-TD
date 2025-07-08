using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PAUSEMENU : MonoBehaviour
{
    public static bool paused = false;
    public GameObject pausemenu, b;
    

    void Start()
    {      
        pausemenu.SetActive(false);
    }

    
  
    public void Resume()
    {
        b.GetComponent<leevelselectionn>().buttonclick.Play();
        pausemenu.SetActive(false);
        Time.timeScale = 1.0f;
        paused = false;
    }

    public void Pause()
    {
        b.GetComponent<leevelselectionn>().buttonclick.Play();
        pausemenu.SetActive(true);
        Time.timeScale = 0f;
        paused = true;
    }
}
