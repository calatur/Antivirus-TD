using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneloader : MonoBehaviour
{
    public int index;
    
    
    public leevelselectionn e;
    public GameObject b;


    public void load()
    {
        Time.timeScale = 1f;
        e = b.GetComponent<leevelselectionn>();
        e.buttonclick.Play();
    
            StartCoroutine(soundwait());
        SceneManager.LoadScene(index);

    }

    IEnumerator soundwait()
    {
        yield return new WaitForSeconds(0.7f);
        SceneManager.LoadScene(index);
        
    }
}
