using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class port : MonoBehaviour

{
    public GameObject test;
    public GameObject canvas;
    bool check;

    
    void Start()
    {
         check = false;
        canvas.SetActive(false);
        test.SetActive(false);
    }
    private void OnMouseDown()
    {
        if (check == false)
        {
            GameObject[] portui = GameObject.FindGameObjectsWithTag("buildui");
            foreach(GameObject port in portui)
            {
                port.SetActive(false);
            }
            canvas.SetActive(true);
            check = true;
         
        }
        else if (check == true){
            GameObject[] portui = GameObject.FindGameObjectsWithTag("buildui");
            foreach (GameObject port in portui)
            {
                port.SetActive(false);
            }
            canvas.SetActive(false);
            check = false;
        }

       
    }
}
