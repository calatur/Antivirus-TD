using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pro : MonoBehaviour
{
    public GameObject losepanel;
    bool check = false;

    private void Start()
    {
      
            losepanel.SetActive(false);
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemy")
        {   if (check == false)
            {
                losepanel.SetActive(true);
                Time.timeScale = 0f;
            }
            check = true;
        }
    }
}
