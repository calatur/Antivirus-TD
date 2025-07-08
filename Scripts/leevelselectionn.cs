using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class leevelselectionn : MonoBehaviour
{
    public AudioSource buttonclick;
    public GameObject main, levels, qmenu;
    public GameObject[] tutorials;
    public int i = 0;
   
    void Start()
    { 
        qmenu.SetActive(false);
    levels.SetActive(false);
        foreach(GameObject tutorial in tutorials)
        {
            
            tutorial.SetActive(false);
        }
    }
    public void showlevels() 
    {
        buttonclick.Play();
        main.SetActive(false); 
        levels.SetActive(true);
    }

    public void back()
    {   buttonclick.Play(); 
        levels.SetActive(false);
        main.SetActive(true);
    }

    public void tutorial()
    {
        buttonclick.Play();
        tutorials[0].SetActive(true);
        i = 0;
    }
    public void next()
    {
        buttonclick.Play();
            tutorials[i+1].SetActive(true);
        if(i>=0)
            tutorials[i].SetActive(false);
        i++;     
    }

    public void finished()
    {
        buttonclick.Play();
        tutorials[i].SetActive(false);
    }

    public void quitmenu()
    {
        buttonclick.Play();
        qmenu.SetActive(true);
    }

    public void Stay()
    {
        buttonclick.Play();
        qmenu.SetActive(false);
    }

    public void Quit()
    {
        buttonclick.Play();
        Application.Quit();
    }

   

}
